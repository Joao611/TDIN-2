using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace StoreServer { 
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
                } catch (SqlException) {
                } finally {
                    c.Close();
                }
            }

            return null;
        }

        public int GetBookStock(int bookId) {
            throw new NotImplementedException();
        }

        public Book[] GetBooks() {
            using (SqlConnection c = new SqlConnection()) {
                
            }
            return null;
        }

        public string SellBook(int value) {
            return string.Format("You entered: {0}", value);
        }

        public Order SetState(int id) {
            throw new NotImplementedException();
        }

        void IStoreService.SellBook(int id) {
            throw new NotImplementedException();
        }
    }
}
