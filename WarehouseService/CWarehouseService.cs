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
    public class CWarehouseService : IWarehouseService {
        string queueName = ".\\private$\\BookShopQueue";
        readonly string database;

        public CWarehouseService() {
            if (!MessageQueue.Exists(queueName)) {
                MessageQueue.Create(queueName, false);
            }
            string connection = ConfigurationManager.ConnectionStrings["WarehouseDB"].ConnectionString;
            database = String.Format(connection, AppDomain.CurrentDomain.BaseDirectory);
        }

        public void requestBooks(string bookTitle, int quantity, Guid orderGuid) {
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "INSERT INTO Requests (Title, Quantity, OrderGuid)" +
                        " VALUES (@title, @quantity, @orderGuid)";
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
    }
}
