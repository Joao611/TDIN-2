using StoreService.WarehouseServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace StoreService {
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CStoreDualService : CStoreService, IStoreDualService {
        private static List<IOrdersChanged> subscribers = new List<IOrdersChanged>();

        private enum OrderType {
            CREATE,
            UPDATE_STATE
        }

        public void Subscribe() {
            IOrdersChanged callback = OperationContext.Current.GetCallbackChannel<IOrdersChanged>();
            if (!subscribers.Contains(callback)) {
                subscribers.Add(callback);
            }
        }


        public void Unsubscribe() {
            IOrdersChanged callback = OperationContext.Current.GetCallbackChannel<IOrdersChanged>();
            subscribers.Remove(callback);
        }

        private void NotifyClients(OrderType type, Order order) {
            subscribers.ForEach(callback => {
                if (((ICommunicationObject)callback).State == CommunicationState.Opened) {
                    switch (type) {
                        case OrderType.CREATE:
                            callback.OrderCreated(order);
                            break;
                        case OrderType.UPDATE_STATE:
                            callback.OrderStateUpdated(order);
                            break;
                    }
                } else {
                    subscribers.Remove(callback);
                }
            });
        }

        private void SendRequest(Request request) {
            subscribers.ForEach(callback => {
                if (((ICommunicationObject)callback).State == CommunicationState.Opened) {
                    callback.AddRequest(request);
                } else {
                    subscribers.Remove(callback);
                }
            });
        }

        public new Order CreateOrder(int clientId, int bookId, int quantity) {
            Order order = base.CreateOrder(clientId, bookId, quantity);
            NotifyClients(OrderType.CREATE, order);
            return order;
        }

        public new Order NotifyFutureArrival(string bookTitle, int quantity, Guid orderGuid) {
            Order order = base.NotifyFutureArrival(bookTitle, quantity, orderGuid);
            NotifyClients(OrderType.UPDATE_STATE, order);
            Request request = new Request(bookTitle, quantity, orderGuid);
            SendRequest(request);
            //[TODO]: Guardar request na DB
            return order;
        }

        public void SatisfyOrders(string bookTitle, int quantity, Guid orderGuid) {
            Request request = new Request(bookTitle, quantity, orderGuid);
            RemoveRequestFromDB(request);
            Book book = GetBookByTitle(request.bookTitle);
            int tmpStock = book.stock + request.quantity;
            Order.State state = new Order.State() {
                type = Order.State.Type.DISPATCHED_AT,
                dispatchDate = DateTime.Now
            };

            Order targetOrder = null;

            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    targetOrder = getOrder(c, request.orderGuid);
                    if(targetOrder.state.type != Order.State.Type.DISPATCHED_AT) {
                        UpdateOrderState(c, request.orderGuid, state);
                        tmpStock -= targetOrder.quantity;
                        targetOrder.state = state;
                    }
                    
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            List<Order> orders = getOrdersByBook(book, tmpStock);
            orders.ForEach(o => {
                if(o.quantity <= tmpStock) {
                    using (SqlConnection c = new SqlConnection(database)) {
                        try {
                            c.Open();
                            UpdateOrderState(c, o.guid, state);
                            o.state = state;
                            tmpStock -= o.quantity;
                        } catch (SqlException e) {
                            Console.WriteLine("DB Exception: " + e);
                        } finally {
                            c.Close();
                        }
                    }
                }
            });

            UpdateBookStock(book.id, tmpStock);
            book.stock = tmpStock;
            orders.Add(targetOrder);
            orders.ForEach(order => {
                order.book = book;
                NotifyClients(OrderType.UPDATE_STATE, order);
            });
            
        }

        private void RemoveRequestFromDB(Request request) {
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "DELETE FROM Requests WHERE Order LIKE @orderGuid";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@orderGuid", request.orderGuid.ToString());
                    cmd.ExecuteNonQuery();
                } catch (Exception e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }
        }

    }

    [ServiceBehavior]
    public class CStoreWebService : CStoreService, IStoreWebService {

    }

    public class CStoreService {
        protected readonly string database;
        private readonly WarehouseQueueServiceClient warehouseProxy;

        public CStoreService() {
            string connection = ConfigurationManager.ConnectionStrings["StoreDB"].ConnectionString;
            database = String.Format(connection, AppDomain.CurrentDomain.BaseDirectory);
            warehouseProxy = new WarehouseQueueServiceClient();
        }

        public List<Order> GetOrders() {
            var orders = new List<Order>();
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "SELECT * FROM Orders";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            Order order = new Order(
                                Guid.Parse(reader["Guid"].ToString()),
                                GetClient(c, Convert.ToInt32(reader["Client"])),
                                GetBook(reader["Book"].ToString()),
                                Convert.ToInt32(reader["Quantity"]),
                                getState(reader["State"].ToString(), Convert.ToDateTime(reader["DispatchDate"]))
                            );
                            orders.Add(order);
                        }
                        reader.Close();
                    }
                } catch (Exception e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return orders;
        }

        public List<Order> GetClientOrders(string clientId) {
            var orders = new List<Order>();
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "SELECT *" +
                                " FROM Orders" +
                                    " INNER JOIN Clients ON (Orders.Client = Clients.Id)" +
                                " WHERE Clients.Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(clientId));
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            Order order = new Order(
                                Guid.Parse(reader["Guid"].ToString()),
                                GetClient(c, Convert.ToInt32(reader["Client"])),
                                GetBook(reader["Book"].ToString()),
                                Convert.ToInt32(reader["Quantity"]),
                                getState(reader["State"].ToString(), Convert.ToDateTime(reader["DispatchDate"]))
                            );
                            orders.Add(order);
                        }
                        reader.Close();
                    }
                } catch (Exception e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return orders;
        }

        public List<Book> GetBooks() {
            var books = new List<Book>();
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "SELECT * FROM Books";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            Book book = new Book() {
                                id = Convert.ToInt32(reader["id"]),
                                title = reader["title"].ToString(),
                                stock = Convert.ToInt32(reader["stock"]),
                                price = Convert.ToDouble(reader["price"]),
                            };
                            books.Add(book);
                        }
                        reader.Close();
                    }
                } catch (Exception e) {
                    Console.WriteLine("Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return books;
        }

        public List<Client> GetClients() {
            List<Client> clients = new List<Client>();
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "SELECT * FROM Clients";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            Client client = new Client() {
                                id = Convert.ToInt32(reader["id"]),
                                name = reader["name"].ToString(),
                                email = reader["email"].ToString(),
                                address = reader["address"].ToString()
                            };
                            clients.Add(client);
                        }
                        reader.Close();
                    }
                } catch (Exception e) {
                    Console.WriteLine("Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return clients;
        }

        public Book GetBook(string id) {
            Book book = null;
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "SELECT * FROM Books" +
                        " WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        reader.Read();
                        book = new Book() {
                            id = Convert.ToInt32(id),
                            title = reader["title"].ToString(),
                            stock = Convert.ToInt32(reader["stock"]),
                            price = Convert.ToDouble(reader["price"])
                        };
                        reader.Close();
                    }
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                } catch (Exception e) {
                    Console.WriteLine("Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return book;
        }

        public Order CreateOrder(int clientId, int bookId, int quantity) {
            if (quantity < 1) {
                WebOperationContext ctx = WebOperationContext.Current;
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return null;
            }
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    Book book = GetBook(bookId.ToString());
                    Order order = new Order(GetClient(c, clientId), book, quantity, getState(book.stock, quantity));
                    InsertOrderInDb(c, order);
                    switch (order.state.type) {
                        case Order.State.Type.WAITING:
                            warehouseProxy.RequestBooks(order.book.title, order.quantity + 10, order.guid);
                            break;
                        case Order.State.Type.DISPATCHED_AT:
                            UpdateStock(c, bookId, -quantity);
                            order.book.stock -= quantity;
                            break;
                        default:
                            Console.WriteLine("oops - CreateOrder()");
                            break;
                    }

                    return order;
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }

            return null;
        }

        public Client CreateClient(string name, string address, string email) {
            Client client = null;
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "INSERT INTO Clients (Name, Email, Address)" +
                        " VALUES (@name, @address, @email);" +
                        " SELECT CAST(scope_identity() AS int)";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@address", address);
                    int clientId = (Int32)cmd.ExecuteScalar();
                    client = new Client() {
                        id = clientId,
                        name = name,
                        email = email,
                        address = address
                    };
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return client;
        }

        public Order NotifyFutureArrival(string bookTitle, int quantity, Guid orderGuid) {
            Request request = new Request(bookTitle, quantity, orderGuid);
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "UPDATE Orders SET State = @s, DispatchDate = @d" +
                        " WHERE Guid LIKE @id AND State <> 'DISPATCHED_AT'";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@s", "DISPATCH_OCCURS_AT");
                    cmd.Parameters.AddWithValue("@d", DateTime.Now.AddDays(2));
                    cmd.Parameters.AddWithValue("@id", request.orderGuid.ToString());
                    cmd.ExecuteNonQuery();

                    Order order = getOrder(c, request.orderGuid);
                    return order;
                } catch (Exception e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }

            return null;
        }

        /** 
         * Private Methods
         **/

        private Order.State getState(int stock, int quantity) {
            if (stock < quantity) {
                return new Order.State() { type = Order.State.Type.WAITING, dispatchDate = DateTime.Now};
            } else {
                return new Order.State() { type = Order.State.Type.DISPATCHED_AT, dispatchDate = DateTime.Now.AddDays(1) };
            }
        }

        private Order.State getState(string stateType, DateTime date) {
            switch (stateType.Trim()) {
                case "WAITING":
                    return new Order.State() { type = Order.State.Type.WAITING, dispatchDate = date };
                case "DISPATCH_OCCURS_AT":
                    return new Order.State() { type = Order.State.Type.DISPATCH_OCCURS_AT, dispatchDate = date };
                case "DISPATCHED_AT":
                    return new Order.State() { type = Order.State.Type.DISPATCHED_AT, dispatchDate = date };
                default:
                    return null;
            }
        }

        protected Order getOrder(SqlConnection c, Guid id) {
            string sql = "SELECT * FROM Orders" +
                        " WHERE Guid LIKE @id";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@id", id.ToString());
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                reader.Read();
                Order order = new Order(
                    id,
                    GetClient(c, Convert.ToInt32(reader["Client"])),
                    GetBook(reader["Book"].ToString()),
                    Convert.ToInt32(reader["Quantity"]),
                    getState(reader["State"].ToString(), Convert.ToDateTime(reader["DispatchDate"]))
                );
                reader.Close();
                return order;
            }
        }

        private Client GetClient(SqlConnection c2, int id) {
            Client client = null;
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "SELECT * FROM Clients" +
                        " WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        reader.Read();
                        client = new Client() {
                            id = id,
                            name = reader["name"].ToString(),
                            email = reader["email"].ToString(),
                            address = reader["address"].ToString()
                        };
                        reader.Close();
                    }
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                } catch (Exception e) {
                    Console.WriteLine("Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return client;
        }

        protected Book GetBookByTitle(string title) {
            Book book = null;
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "SELECT * FROM Books" +
                        " WHERE Title LIKE @title";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@title", title);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        reader.Read();
                        book = new Book() {
                            id = Convert.ToInt32(reader["Id"]),
                            title = reader["Title"].ToString(),
                            stock = Convert.ToInt32(reader["stock"]),
                            price = Convert.ToDouble(reader["price"])
                        };
                        reader.Close();
                    }
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                } catch (Exception e) {
                    Console.WriteLine("Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return book;
        }

        private void InsertOrderInDb(SqlConnection c, Order order) {
            string sql = "INSERT INTO Orders (Guid, Client, Book, Quantity, State, DispatchDate)" +
                        " VALUES (@guid, @c, @b, @qty, @state, @date)";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@guid", order.guid.ToString());
            cmd.Parameters.AddWithValue("@c", order.client.id);
            cmd.Parameters.AddWithValue("@b", order.book.id);
            cmd.Parameters.AddWithValue("@qty", order.quantity);
            cmd.Parameters.AddWithValue("@state", order.state.type.ToString());
            cmd.Parameters.AddWithValue("@date", order.state.dispatchDate);
            cmd.ExecuteNonQuery();
        }

        private void UpdateStock(SqlConnection c, int bookId, int quantity) {
            string sql = "UPDATE Books SET Stock = Stock + @q" +
                        " WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@q", quantity);
            cmd.Parameters.AddWithValue("@id", bookId);
            cmd.ExecuteNonQuery();
        }

        /*private Order SetState(string id, string stateType) {
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    Order.State state = nextState(stateType);
                    UpdateOrderState(c, id, state);
                    Order order = getOrder(c, Guid.Parse(id));
                    return order;
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                }
                return null;
            }
        }*/

        protected void UpdateOrderState(SqlConnection c, Guid guid, Order.State state) {
            string sql = "UPDATE Orders SET State = @s, DispatchDate = @d" +
                        " WHERE Guid LIKE @id";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@s", state.type.ToString());
            cmd.Parameters.AddWithValue("@d", state.dispatchDate);
            cmd.Parameters.AddWithValue("@id", guid.ToString());
            cmd.ExecuteNonQuery();
        }

        // [TODO]: Correct this. One order can pass from WAITING directly to DISPATCHED_AT
        private Order.State nextState(string stateType) {
            switch (stateType) {
                case "WAITING":
                    return new Order.State() { type = Order.State.Type.DISPATCH_OCCURS_AT, dispatchDate = DateTime.Now.AddDays(2) };
                case "DISPATCH_OCCURS_AT":
                    return new Order.State() { type = Order.State.Type.DISPATCHED_AT, dispatchDate = DateTime.Now };
                default:
                    return null;
            }
        }

        

        protected List<Order> getOrdersByBook(Book book, int stock) {
            List<Order> orders = new List<Order>();
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "SELECT * FROM Orders" +
                        " WHERE Book = @bookId AND State <> 'DISPATCHED_AT' AND Quantity <= @stock";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@bookId", book.id);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            Order order = new Order(
                                Guid.Parse(reader["Guid"].ToString()),
                                GetClient(c, Convert.ToInt32(reader["Client"])),
                                book,
                                Convert.ToInt32(reader["Quantity"]),
                                getState(reader["State"].ToString(), Convert.ToDateTime(reader["DispatchDate"]))
                            );
                            orders.Add(order);
                        }
                        reader.Close();
                    }
                } catch (Exception e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return orders;
        }

        protected void UpdateBookStock(int bookId, int stock) {
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "UPDATE Books SET Stock = @s" +
                        " WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@s", stock);
                    cmd.Parameters.AddWithValue("@id", bookId);
                    cmd.ExecuteNonQuery();
                } catch (Exception e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }
        }

    }
}
