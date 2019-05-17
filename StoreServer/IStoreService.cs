using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StoreServer {
    [ServiceContract]
    public interface IStoreService {
        // updates store stock and prints receipt, bypasses order?
        [OperationContract]
        void SellBook(int bookId);

        [OperationContract]
        int GetBookStock(int bookId);

        [OperationContract]
        Book[] GetBooks();

        [OperationContract]
        Order CreateOrder(int clientId, int bookId, int quantity);

        [OperationContract]
        Order SetState(int id);
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

    /**
     * Order for each book. Orders are always delivered at home, so there are no instant sells.
     * An Order may need to wait for the warehouse to delivered the respective book title.
     */ 
    [DataContract]
    public class Order {
        public class State {
            public enum Type {
                WAITING,
                DISPATCH_OCCURS_AT,
                DISPATCHED_AT,
            }
            public Type type;
            public DateTime dispatchDate;
        }

        public Order(Client client, Book book, int quantity) {
            guid = Guid.NewGuid();
            this.book = book;
            this.quantity = quantity;
            this.client = client;
            totalPrice = quantity * book.price;
            if (book.stock >= quantity) {
                state = new State() { type = State.Type.DISPATCH_OCCURS_AT, dispatchDate = DateTime.Now.AddDays(1) };
            } else {
                state = new State() { type = State.Type.WAITING };
            }
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
}
