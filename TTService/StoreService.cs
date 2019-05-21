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

        private Client GetClient(SqlConnection c, int id) {
            string sql = "SELECT * FROM Clients" +
                        "WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                reader.Read();
                return new Client() {
                    id = id,
                    name = reader["name"].ToString(),
                    email = reader["email"].ToString(),
                    address = reader["address"].ToString()
                };
            }
        }

        private Book GetBook(SqlConnection c, int id) {
            string sql = "SELECT * FROM Books" +
                        "WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                reader.Read();
                return new Book() {
                    id = id,
                    title = reader["title"].ToString(),
                    stock = Convert.ToInt32(reader["stock"])
                };
            }
        }

        private void InsertOrderInDb(SqlConnection c, Order order) {
            string sql = "INSERT INTO Orders(guid, client, book, quantity, state, dispatch_date" +
                        " VALUES (@guid, @c, @b, @qty, @state, @date)";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@guid", order.guid);
            cmd.Parameters.AddWithValue("@c", order.client.id);
            cmd.Parameters.AddWithValue("@b", order.book.id);
            cmd.Parameters.AddWithValue("@qty", order.quantity);
            cmd.Parameters.AddWithValue("@state", order.state.type);
            cmd.Parameters.AddWithValue("@date", order.state.dispatchDate);
            cmd.ExecuteNonQuery();
        }

        private void UpdateStock(SqlConnection c, int bookId, int quantity) {
            string sql = "UPDATE Books SET stock = stock + @q" +
                        " WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@q", quantity);
            cmd.Parameters.AddWithValue("@id", bookId);
            cmd.ExecuteNonQuery();
        }

        public Order CreateOrder(int clientId, int bookId, int quantity) {

            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();

                    Order order = new Order(GetClient(c, clientId), GetBook(c, bookId), quantity);
                    InsertOrderInDb(c, order);
                    switch (order.state.type) {
                        case Order.State.Type.WAITING:
                            // TODO: warehouse MSMQ request
                            break;
                        case Order.State.Type.DISPATCH_OCCURS_AT:
                            UpdateStock(c, bookId, -quantity);
                            break;
                        default:
                            Console.WriteLine("oops - CreateOrder()");
                            break;
                    }

                    return order;
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                }
            }

            return null;
        }

        public List<Book> GetBooks() {
            var books = new List<Book>();
            Console.WriteLine("-------------------------------------");
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
                }
                } catch (Exception e) {
                    Console.WriteLine("DB Exception: " + e);
                }
            }
            return books;
        }

        public Order SetState(string id) {
            throw new NotImplementedException();
        }

        public void SellBook(int id, int bookId, int quantity, int clientId) {
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();

                    Order order = new Order(GetClient(c, clientId), GetBook(c, bookId), quantity);
                    InsertOrderInDb(c, order);
                    switch (order.state.type) {
                        case Order.State.Type.WAITING:
                            // TODO: warehouse MSMQ request
                            break;
                        case Order.State.Type.DISPATCH_OCCURS_AT:
                            UpdateStock(c, bookId, -quantity);
                            break;
                        default:
                            Console.WriteLine("oops - CreateOrder()");
                            break;
                    }

                    return order;
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                }
            }
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
