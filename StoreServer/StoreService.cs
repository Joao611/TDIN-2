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

        public Order CreateOrder(int id) {
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
                } catch (SqlException) {
                } finally {
                    c.Close();
                }
            }
            return id;
        }

        public int GetBookStock(int id) {
            throw new NotImplementedException();
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
