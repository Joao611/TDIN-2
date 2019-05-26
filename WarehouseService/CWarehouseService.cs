using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Messaging;
using System.Data.SqlClient;
using WarehouseService.StoreServiceReference;

namespace WarehouseService {
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CWarehouseService : IWarehouseQueueService, IWarehouseService, IStoreDualServiceCallback {
        private readonly string database;
        private static List<IRequestsChanged> subscribers = new List<IRequestsChanged>();
        private StoreDualServiceClient proxy;

        private enum RequestType {
            CREATE,
            UPDATE_STATE
        }

        public CWarehouseService() {
            string connection = ConfigurationManager.ConnectionStrings["WarehouseDB"].ConnectionString;
            database = String.Format(connection, AppDomain.CurrentDomain.BaseDirectory);
            proxy = new StoreDualServiceClient(new InstanceContext(this));
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
            subscribers.ForEach(callback => {
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
                    string sql = "INSERT INTO Requests (BookTitle, Quantity, OrderGuid)" +
                        " VALUES (@title, @quantity, @guid)";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@title", bookTitle);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@guid", orderGuid.ToString());
                    cmd.ExecuteNonQuery();
                    Request request = new Request(bookTitle, quantity, orderGuid);
                    NotifyClients(RequestType.CREATE, request);
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
                            Request request = new Request(bookTitle, quantity, orderGuid);
                            requests.Add(request);
                        }
                        reader.Close();
                    }
                } catch (Exception e) {
                    Console.WriteLine("Exception: " + e.Message);
                } finally {
                    c.Close();
                }
            }
            return requests;
        }

        public void SendBooks(string bookTitle, int quantity, Guid orderGuid) {
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    Request request = new Request(bookTitle, quantity, orderGuid);
                    RemoveRequestFromDB(request);
                    NotifyClients(RequestType.UPDATE_STATE, request);
                    proxy.NotifyFutureArrival(bookTitle, quantity, orderGuid);
                } catch (Exception e) {
                    Console.WriteLine("Exception: " + e.Message);
                } finally {
                    c.Close();
                }
            }
        }

        private void RemoveRequestFromDB(Request request) {
            using (SqlConnection c = new SqlConnection(database)) {
                try {
                    c.Open();
                    string sql = "DELETE FROM Requests WHERE OrderGuid LIKE @orderGuid";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.Parameters.AddWithValue("@orderGuid", request.orderGuid.ToString());
                    cmd.ExecuteNonQuery();
                } catch (Exception e) {
                    Console.WriteLine("DB Exception: " + e.Message);
                } finally {
                    c.Close();
                }
            }
        }

        /**
         * Functions below only defined so we can call the Store's dual service.
         * They may remain throwing an exception because the Warehouse
         * never subscribes to the Store, thus these callbacks are never called.
         */

        public void OrderCreated(Order order) {
            throw new NotImplementedException();
        }

        public void OrderStateUpdated(Order order) {
            throw new NotImplementedException();
        }

        public void AddRequest(StoreServiceReference.Request request) {
            throw new NotImplementedException();
        }

        public void DeleteRequest(StoreServiceReference.Request request) {
            throw new NotImplementedException();
        }

        public void ClientAdded(Client client) {
            throw new NotImplementedException();
        }
    }
}
