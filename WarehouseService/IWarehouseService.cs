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

    [ServiceContract]
    public interface IWarehouseService {
        [WebGet(UriTemplate = "/requests", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Request> GetRequests();

        [WebInvoke(Method = "POST", UriTemplate = "/requests", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void SendBooks(Request request);
    }

    [DataContract]
    public class Request {

        public Request(int id, string bookTitle, int quantity, Guid orderGuid, bool ready) {
            this.id = id;
            this.bookTitle = bookTitle;
            this.quantity = quantity;
            this.orderGuid = orderGuid;
            this.ready = ready;
        }

        [DataMember]
        public int id { get; private set; }

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
