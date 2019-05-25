using StoreService.WarehouseServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace StoreService {
    [ServiceContract]
    public interface IStoreWebService {

        [WebGet(UriTemplate = "/books", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Book> GetBooks();

        [WebGet(UriTemplate = "/clients", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Client> GetClients();

        [WebGet(UriTemplate = "/clients/{clientId}/orders", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Order> GetClientOrders(string clientId);

        [WebGet(UriTemplate = "/books/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Book GetBook(string id);

        [WebGet(UriTemplate = "/orders", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Order> GetOrders();

        [WebInvoke(Method = "POST", UriTemplate = "/orders", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Order CreateOrder(int clientId, int bookId, int quantity);

        [WebInvoke(Method = "POST", UriTemplate = "/clients", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Client CreateClient(string name, string address, string email);

        //[TODO]: shoul we pass the {id} (oreder id) in the uri??? The warehouse currently doesn't know the order's id, just the Guid
        [WebInvoke(Method = "PATCH", UriTemplate = "/orders", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Order NotifyFutureArrival(string bookTitle, int quantity, Guid orderGuid);
    }

    [ServiceContract(CallbackContract = typeof(IOrdersChanged))]
    public interface IStoreDualService {

        [OperationContract]
        void Subscribe();

        [OperationContract]
        void Unsubscribe();

        [OperationContract]
        List<Book> GetBooks();

        [OperationContract]
        List<Client> GetClients();

        [OperationContract]
        List<Order> GetClientOrders(string clientId);

        [OperationContract]
        Book GetBook(string id);

        [OperationContract]
        List<Order> GetOrders();

        [OperationContract]
        Order CreateOrder(int clientId, int bookId, int quantity);

        [OperationContract]
        Client CreateClient(string name, string address, string email);

        //[TODO]: shoul we pass the {id} (oreder id) in the uri??? The warehouse currently doesn't know the order's id, just the Guid
        [OperationContract]
        Order NotifyFutureArrival(string bookTitle, int quantity, Guid orderGuid);

        [OperationContract]
        void SatisfyOrders(string bookTitle, int quantity, Guid orderGuid);

        [OperationContract]
        List<Request> GetRequests();
    }

    public interface IOrdersChanged {

        [OperationContract(IsOneWay = true)]
        void OrderCreated(Order order);

        [OperationContract(IsOneWay = true)]
        void OrderStateUpdated(Order order);

        [OperationContract(IsOneWay = true)]
        void AddRequest(Request request);
    }

    /**
     * Order for each book. Orders are always delivered at home, so there are no instant sells.
     * An Order may need to wait for the warehouse to delivered the respective book title.
     */
    [DataContract]
    public class Order {
        public class State {
            [DataContract]
            public enum Type {
                [EnumMember] DELIVERED,
                [EnumMember] WAITING,
                [EnumMember] DISPATCH_OCCURS_AT,
                [EnumMember] DISPATCHED_AT,
            }
            public Type type;
            public DateTime dispatchDate;
            
        }

        public Order(Client client, Book book, int quantity, Order.State state) {
            guid = Guid.NewGuid();
            this.book = book;
            this.quantity = quantity;
            this.client = client;
            this.state = state;
            totalPrice = quantity * book.price;
        }

        public Order(Guid guid, Client client, Book book, int quantity, Order.State state) {
            this.guid = guid;
            this.book = book;
            this.quantity = quantity;
            this.client = client;
            this.state = state;
            totalPrice = quantity * book.price;
        }

        [DataMember]
        public Guid guid { get; private set; }

        [DataMember]
        public Book book { get; set; }

        [DataMember]
        public int quantity { get; private set; }

        [DataMember]
        public Client client { get; private set; }

        [DataMember]
        public double totalPrice { get; private set; }

        [DataMember]
        public State state { get; set; }
        
    }

    public class Client {
        public int id;
        public string email;
        public string name;
        public string address;
    }

    public class Book {
        public int id;
        public string title;
        public int stock;
        public double price;
    }

    [DataContract]
    public class Request {

        public Request(string bookTitle, int quantity, Guid orderGuid) {
            this.bookTitle = bookTitle;
            this.quantity = quantity;
            this.orderGuid = orderGuid;
        }

        [DataMember]
        public string bookTitle { get; private set; }

        [DataMember]
        public int quantity { get; private set; }

        [DataMember]
        public Guid orderGuid { get; private set; }

        [DataMember]
        public bool ready { get; private set; }
    }
}
