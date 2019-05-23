using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace StoreService {
    [ServiceContract]
    public interface IStoreService {

        [WebGet(UriTemplate = "/books", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Book> GetBooks();

        [WebGet(UriTemplate = "/clients", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Client> GetClients();
        
        [WebGet(UriTemplate = "/books/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Book GetBook(string id);

        [WebGet(UriTemplate = "/orders", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Order> GetOrders();

        [WebInvoke(Method = "POST", UriTemplate = "/orders", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Order CreateOrder(int clientId, int bookId, int quantity, bool instantSell);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Order SellBook(int bookId, int quantity, int clientId);

        [WebInvoke(Method = "PATCH", UriTemplate = "/orders/{id}/state", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Order SetState(string id, string stateType);

        [WebInvoke(Method = "POST", UriTemplate = "/clients", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Client CreateClient(string name, string address, string email);
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

        [DataMember]
        public Guid guid { get; private set; }

        [DataMember]
        public Book book { get; private set; }

        [DataMember]
        public int quantity { get; private set; }

        [DataMember]
        public Client client { get; private set; }

        [DataMember]
        public double totalPrice { get; private set; }

        [DataMember]
        public State state { get; private set; }
        
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
}
