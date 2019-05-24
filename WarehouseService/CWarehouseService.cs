using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Messaging;
using System.Data.SqlClient;

namespace WarehouseService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CWarehouseService : IWarehouseQueueService, IWarehouseService {
        string queueName = ".\\private$\\BookShopQueue";
        readonly string database;

        public CWarehouseService() {
            if (!MessageQueue.Exists(queueName)) {
                MessageQueue.Create(queueName, false);
            }
            string connection = ConfigurationManager.ConnectionStrings["WarehouseDB"].ConnectionString;
            database = String.Format(connection, AppDomain.CurrentDomain.BaseDirectory);
        }

        public void RequestBooks(string bookTitle, int quantity, Guid orderGuid) {
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "INSERT INTO Requests (BookTitle, Quantity, OrderGuid, Ready)" +
                        " VALUES (@title, @quantity, @orderGuid, 0)";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@title", bookTitle);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@orderId", orderGuid);
                    cmd.ExecuteNonQuery();
                } catch (SqlException e) {
                    Console.WriteLine("DB Exception: " + e);
                } finally {
                    c.Close();
                }
            }
        }

        public List<Request> GetRequests() {
            List<Request> requests = new List<Request>();
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "SELECT * FROM Requests";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            int id = Convert.ToInt32(reader["Id"]);
                            string bookTitle = reader["BookTitle"].ToString();
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            Guid orderGuid = Guid.Parse(reader["OrderGuid"].ToString());
                            bool ready = Convert.ToInt16(reader["Ready"]) == 0 ? false : true;
                            Request request = new Request(id, bookTitle, quantity, orderGuid, ready);
                            requests.Add(request);
                        }
                        reader.Close();
                    }
                } catch (Exception e) {
                    Console.WriteLine("Exception: " + e);
                } finally {
                    c.Close();
                }
            }
            return requests;
        }

        public void SendBooks(Request request) {
            throw new NotImplementedException();
        }
    }
}
