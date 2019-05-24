using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WarehouseService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWarehouseQueueService {
        [OperationContract(IsOneWay = true)]
        void RequestBooks(string bookTitle, int quantity, Guid orderGuid);
    }

    [ServiceContract(CallbackContract=typeof(IRequestsChanged))]
    public interface IWarehouseService {
        [OperationContract]
        void Subscribe();

        [OperationContract]
        void Unsubscribe();

        [OperationContract]
        List<Request> GetRequests();

        [OperationContract]
        void SendBooks(Request request);
    }

    public interface IRequestsChanged {
        [OperationContract(IsOneWay = true)]
        void RequestCreated(Request request);

        [OperationContract(IsOneWay=true)]
        void RequestStateUpdated(Request request);
    }

    [DataContract]
    public class Request {

        public Request(string bookTitle, int quantity, Guid orderGuid, bool ready) {
            this.bookTitle = bookTitle;
            this.quantity = quantity;
            this.orderGuid = orderGuid;
            this.ready = ready;
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
