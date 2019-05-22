using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StoreService {
    public class StoreService : IStoreService {
        readonly string database;

        StoreService() {
            string connection = ConfigurationManager.ConnectionStrings["StoreDB"].ConnectionString;
            database = String.Format(connection, AppDomain.CurrentDomain.BaseDirectory);
        }

        private Order.State getState(int stock, int quantity, bool instantSell) {
            if (stock < quantity) {
                return new Order.State() { type = Order.State.Type.WAITING };
            } else {
                if (instantSell) {
                    return new Order.State() { type = Order.State.Type.DELIVERED, dispatchDate = DateTime.Now };
                } else {
                    return new Order.State() { type = Order.State.Type.DISPATCH_OCCURS_AT, dispatchDate = DateTime.Now.AddDays(1) };
                }
            }
        }

        private Order.State getState(string stateType, DateTime date) {
            switch (stateType.Trim()) {
                case "DELIVERED":
                    return new Order.State() { type = Order.State.Type.DELIVERED, dispatchDate = date };
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

        private Order.State nextState(string stateType) {
            switch (stateType) {
                case "WAITING":
                    return new Order.State() { type = Order.State.Type.DISPATCH_OCCURS_AT, dispatchDate = DateTime.Now.AddDays(1) };
                case "DISPATCH_OCCURS_AT":
                    return new Order.State() { type = Order.State.Type.DISPATCHED_AT, dispatchDate = DateTime.Now.AddDays(2) };
                default:
                    return null;
            }
        }

        private Order getOrder(SqlConnection c, int id) {
            string sql = "SELECT * FROM Orders" +
                        " WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                reader.Read();
                Order order = new Order(GetClient(c, Convert.ToInt32(reader["Client"])),
                    GetBook(reader["Book"].ToString()),
                    Convert.ToInt32(reader["Quantity"]),
                    getState(reader["State"].ToString(), reader.GetDateTime(6)));//is 6 the index of DispatchDate column???
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
                } finally {
                    c.Close();
                }
            }
            return client;
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

        private void InsertOrderInDb(SqlConnection c, Order order) {
            string sql = "INSERT INTO Orders (Guid, Client, Book, Quantity, State, DispatchDate)" +
                        " VALUES (@guid, @c, @b, @qty, @state, @date)";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@guid", order.guid.ToString());
            cmd.Parameters.AddWithValue("@c", order.client.id);
            cmd.Parameters.AddWithValue("@b", order.book.id);
            cmd.Parameters.AddWithValue("@qty", order.quantity);
            cmd.Parameters.AddWithValue("@state", order.state.type.ToString());
            cmd.Parameters.AddWithValue("@date", order.state.dispatchDate.ToString("s"));
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

        private void UpdateOrderState(SqlConnection c, string id, Order.State state) {
            string sql = "UPDATE Orders SET State = @s, DispatchDate = @d" +
                        " WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@s", state.type.ToString());
            cmd.Parameters.AddWithValue("@d", state.dispatchDate);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            cmd.ExecuteNonQuery();
        }

        public Order CreateOrder(int clientId, int bookId, int quantity, bool instantSell) {

            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    Book book = GetBook(bookId.ToString());
                    Order order = new Order(GetClient(c, clientId), book, quantity, getState(book.stock, quantity, instantSell));
                    InsertOrderInDb(c, order);
                    switch (order.state.type) {
                        case Order.State.Type.WAITING:
                            // TODO: warehouse MSMQ request
                            break;
                        case Order.State.Type.DISPATCH_OCCURS_AT:
                            UpdateStock(c, bookId, -quantity);
                            break;
                        case Order.State.Type.DELIVERED:
                            UpdateStock(c, bookId, -quantity);
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
                                GetClient(c, Convert.ToInt32(reader["Client"])),
                                GetBook(reader["Book"].ToString()),
                                Convert.ToInt32(reader["Quantity"]),
                                getState(reader["State"].ToString(), reader.GetDateTime(6))
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
                                stock = Convert.ToInt32(reader["stock"])
                            };
                            books.Add(book);
                        }
                        reader.Close();
                    }
                } catch (Exception e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return books;
        }

        public Order SetState(string id, string stateType) {
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    Order.State state = nextState(stateType);
                    UpdateOrderState(c, id, state);
                    Order order = getOrder(c, Convert.ToInt32(id));
                    return order;
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                }
                return null;
            }
        }



        public void SellBook(int id, int bookId, int quantity, int clientId) {
            CreateOrder(clientId, bookId, quantity, true);
        }

        /*

        public int AddTicket(string author, string problem) {
            int id = 0;

            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "insert into TTickets(Author, Problem, Answer, Status) values (@a1, @p1, '', 1)"; // injection protection
                    SqlCommand cmd = new SqlCommand(sql, c);                                                       // injection protection
                    cmd.Parameters.AddWithValue("@a1", author);                                                    // injection protection
                    cmd.Parameters.AddWithValue("@p1", problem);                                                   // injection protection
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select max(Id) from TTickets";
                    id = (int)cmd.ExecuteScalar();
                }
                catch (SqlException) {
                }
                finally {
                    c.Close();
                }
            }
            return id;
        }

        public DataTable GetTickets(string author) {
            DataTable result = new DataTable("TTickets");

            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "select Id, Problem, Status, Answer from TTickets where Author=@a1";         // injection protection
                    SqlCommand cmd = new SqlCommand(sql, c);                                                  // injection protection
                    cmd.Parameters.AddWithValue("@a1", author);                                               // injection protection
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(result);
                }
                catch (SqlException) {
                }
                finally {
                    c.Close();
                }
            }
            return result;
        }

        public DataTable GetUsers() {
            DataTable result = new DataTable("Users");

            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "select * from Employees";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(result);
                }
                catch (SqlException) {
                }
                finally {
                    c.Close();
                }
            }
            return result;
        }*/
    }
}
