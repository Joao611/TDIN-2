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
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class CWarehouseService : IWarehouseQueueService, IWarehouseService {
        private readonly string database;
        private static List<IRequestsChanged> subscribers = new List<IRequestsChanged>();

        private enum RequestType {
            CREATE,
            UPDATE_STATE
        }

        public CWarehouseService() {
            string connection = ConfigurationManager.ConnectionStrings["WarehouseDB"].ConnectionString;
            database = String.Format(connection, AppDomain.CurrentDomain.BaseDirectory);
        }

        public void Subscribe() {
            IRequestsChanged callback = OperationContext.Current.GetCallbackChannel<IRequestsChanged>();
            if (!subscribers.Contains(callback)) {
                subscribers.Add(callback);
            }
        }

        public void Unsubscribe() {
            IRequestsChanged callback = OperationContext.Current.GetCallbackChannel<IRequestsChanged>();
            subscribers.Remove(callback);
        }

        private void NotifyClients(RequestType type, Request request) {
            subscribers.ForEach(delegate(IRequestsChanged callback) {
                if (((ICommunicationObject)callback).State == CommunicationState.Opened) {
                    switch (type) {
                        case RequestType.CREATE:
                            callback.RequestCreated(request);
                            break;
                        case RequestType.UPDATE_STATE:
                            callback.RequestStateUpdated(request);
                            break;
                    }
                } else {
                    subscribers.Remove(callback);
                }
            });
        }

        public void RequestBooks(string bookTitle, int quantity, Guid orderGuid) {
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "INSERT INTO Requests (BookTitle, Quantity, OrderGuid, Ready)" +
                        " VALUES (@title, @quantity, @guid, 0)";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@title", bookTitle);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@guid", orderGuid.ToString());
                    cmd.ExecuteNonQuery();
                    NotifyClients(RequestType.CREATE, new Request(bookTitle, quantity, orderGuid, false));
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
                            string bookTitle = reader["BookTitle"].ToString();
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            Guid orderGuid = Guid.Parse(reader["OrderGuid"].ToString());
                            bool ready = Convert.ToInt16(reader["Ready"]) == 0 ? false : true;
                            Request request = new Request(bookTitle, quantity, orderGuid, ready);
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
