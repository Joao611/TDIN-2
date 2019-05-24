﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel.Web;

namespace StoreService {
    public class CStoreService : IStoreService {
        readonly string database;

        CStoreService() {
            string connection = ConfigurationManager.ConnectionStrings["StoreDB"].ConnectionString;
            database = String.Format(connection, AppDomain.CurrentDomain.BaseDirectory);
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
                            // TODO: warehouse MSMQ request
                            break;
                        case Order.State.Type.DISPATCH_OCCURS_AT:
                            UpdateStock(c, bookId, -quantity);
                            order.book.stock -= quantity;
                            break;
                        case Order.State.Type.DELIVERED:
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
        
        public Order SetState(string id, string stateType) {
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

        /** 
         * Private Methods
         **/

        private Order.State getState(int stock, int quantity) {
            if (stock < quantity) {
                return new Order.State() { type = Order.State.Type.WAITING };
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
                default:
                    return null;
            }
        }

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

        private Order getOrder(SqlConnection c, Guid id) {
            string sql = "SELECT * FROM Orders" +
                        " WHERE Guid = @id";
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
                } catch (Exception e) {
                    Console.WriteLine("Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return client;
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
    }
}
