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
        void SellBook(int id);

        [OperationContract]
        int GetBookStock(int id);

        [OperationContract]
        Order CreateOrder(int id);

        [OperationContract]
        Order SetState(int id);
    }

    public class Client {
        private string email { get; }
        private string name { get; }
        private string address { get; }
    }

    /**
     * Order for each book. Orders are always delivered at home, so there are no instant sells.
     * An Order may need to wait for the warehouse to delivered the respective book title.
     */ 
    [DataContract]
    public class Order {
        public class State {
            enum Type {
                WAITING,
                DISPATCH_OCCURS_AT,
                DISPATCH_AT,
            }
            private Type type { get; }
            private DateTime dispatchDate { get; }
        }

        [DataMember]
        private string guid { get; }

        [DataMember]
        private string title { get; }

        [DataMember]
        private int quantity { get; }

        [DataMember]
        private Client client { get; }

        [DataMember]
        private int totalPrice { get; }

        [DataMember]
        private State state { get; }
    }
}
