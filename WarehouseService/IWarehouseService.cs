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
        void SendBooks(string bookTitle, int quantity, Guid orderGuid);
    }

    public interface IRequestsChanged {
        [OperationContract(IsOneWay = true)]
        void RequestCreated(Request request);

        [OperationContract(IsOneWay=true)]
        void RequestStateUpdated(Request request);
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
    }
}
