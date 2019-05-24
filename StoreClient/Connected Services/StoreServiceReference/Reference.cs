﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreClient.StoreServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Book", Namespace="http://schemas.datacontract.org/2004/07/StoreService")]
    [System.SerializableAttribute()]
    public partial class Book : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double priceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int stockField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string titleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double price {
            get {
                return this.priceField;
            }
            set {
                if ((this.priceField.Equals(value) != true)) {
                    this.priceField = value;
                    this.RaisePropertyChanged("price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int stock {
            get {
                return this.stockField;
            }
            set {
                if ((this.stockField.Equals(value) != true)) {
                    this.stockField = value;
                    this.RaisePropertyChanged("stock");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string title {
            get {
                return this.titleField;
            }
            set {
                if ((object.ReferenceEquals(this.titleField, value) != true)) {
                    this.titleField = value;
                    this.RaisePropertyChanged("title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Client", Namespace="http://schemas.datacontract.org/2004/07/StoreService")]
    [System.SerializableAttribute()]
    public partial class Client : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string addressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string address {
            get {
                return this.addressField;
            }
            set {
                if ((object.ReferenceEquals(this.addressField, value) != true)) {
                    this.addressField = value;
                    this.RaisePropertyChanged("address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/StoreService")]
    [System.SerializableAttribute()]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private StoreClient.StoreServiceReference.Book bookField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private StoreClient.StoreServiceReference.Client clientField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid guidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private StoreClient.StoreServiceReference.Order.State stateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double totalPriceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public StoreClient.StoreServiceReference.Book book {
            get {
                return this.bookField;
            }
            set {
                if ((object.ReferenceEquals(this.bookField, value) != true)) {
                    this.bookField = value;
                    this.RaisePropertyChanged("book");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public StoreClient.StoreServiceReference.Client client {
            get {
                return this.clientField;
            }
            set {
                if ((object.ReferenceEquals(this.clientField, value) != true)) {
                    this.clientField = value;
                    this.RaisePropertyChanged("client");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid guid {
            get {
                return this.guidField;
            }
            set {
                if ((this.guidField.Equals(value) != true)) {
                    this.guidField = value;
                    this.RaisePropertyChanged("guid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int quantity {
            get {
                return this.quantityField;
            }
            set {
                if ((this.quantityField.Equals(value) != true)) {
                    this.quantityField = value;
                    this.RaisePropertyChanged("quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public StoreClient.StoreServiceReference.Order.State state {
            get {
                return this.stateField;
            }
            set {
                if ((object.ReferenceEquals(this.stateField, value) != true)) {
                    this.stateField = value;
                    this.RaisePropertyChanged("state");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double totalPrice {
            get {
                return this.totalPriceField;
            }
            set {
                if ((this.totalPriceField.Equals(value) != true)) {
                    this.totalPriceField = value;
                    this.RaisePropertyChanged("totalPrice");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="Order.State", Namespace="http://schemas.datacontract.org/2004/07/StoreService")]
        [System.SerializableAttribute()]
        public partial class State : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
            
            [System.NonSerializedAttribute()]
            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.DateTime dispatchDateField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private StoreClient.StoreServiceReference.Order.State.Type typeField;
            
            public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
                get {
                    return this.extensionDataField;
                }
                set {
                    this.extensionDataField = value;
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute()]
            public System.DateTime dispatchDate {
                get {
                    return this.dispatchDateField;
                }
                set {
                    if ((this.dispatchDateField.Equals(value) != true)) {
                        this.dispatchDateField = value;
                        this.RaisePropertyChanged("dispatchDate");
                    }
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute()]
            public StoreClient.StoreServiceReference.Order.State.Type type {
                get {
                    return this.typeField;
                }
                set {
                    if ((this.typeField.Equals(value) != true)) {
                        this.typeField = value;
                        this.RaisePropertyChanged("type");
                    }
                }
            }
            
            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
            
            protected void RaisePropertyChanged(string propertyName) {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
                if ((propertyChanged != null)) {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
            
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
            [System.Runtime.Serialization.DataContractAttribute(Name="Order.State.Type", Namespace="http://schemas.datacontract.org/2004/07/StoreService")]
            public enum Type : int {
                
                [System.Runtime.Serialization.EnumMemberAttribute()]
                DELIVERED = 0,
                
                [System.Runtime.Serialization.EnumMemberAttribute()]
                WAITING = 1,
                
                [System.Runtime.Serialization.EnumMemberAttribute()]
                DISPATCH_OCCURS_AT = 2,
                
                [System.Runtime.Serialization.EnumMemberAttribute()]
                DISPATCHED_AT = 3,
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Request", Namespace="http://schemas.datacontract.org/2004/07/WarehouseService")]
    [System.SerializableAttribute()]
    public partial class Request : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string bookTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid orderGuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool readyField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string bookTitle {
            get {
                return this.bookTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.bookTitleField, value) != true)) {
                    this.bookTitleField = value;
                    this.RaisePropertyChanged("bookTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid orderGuid {
            get {
                return this.orderGuidField;
            }
            set {
                if ((this.orderGuidField.Equals(value) != true)) {
                    this.orderGuidField = value;
                    this.RaisePropertyChanged("orderGuid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int quantity {
            get {
                return this.quantityField;
            }
            set {
                if ((this.quantityField.Equals(value) != true)) {
                    this.quantityField = value;
                    this.RaisePropertyChanged("quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ready {
            get {
                return this.readyField;
            }
            set {
                if ((this.readyField.Equals(value) != true)) {
                    this.readyField = value;
                    this.RaisePropertyChanged("ready");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StoreServiceReference.IStoreService")]
    public interface IStoreService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetBooks", ReplyAction="http://tempuri.org/IStoreService/GetBooksResponse")]
        StoreClient.StoreServiceReference.Book[] GetBooks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetBooks", ReplyAction="http://tempuri.org/IStoreService/GetBooksResponse")]
        System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Book[]> GetBooksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetClients", ReplyAction="http://tempuri.org/IStoreService/GetClientsResponse")]
        StoreClient.StoreServiceReference.Client[] GetClients();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetClients", ReplyAction="http://tempuri.org/IStoreService/GetClientsResponse")]
        System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Client[]> GetClientsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetClientOrders", ReplyAction="http://tempuri.org/IStoreService/GetClientOrdersResponse")]
        StoreClient.StoreServiceReference.Order[] GetClientOrders(string clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetClientOrders", ReplyAction="http://tempuri.org/IStoreService/GetClientOrdersResponse")]
        System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Order[]> GetClientOrdersAsync(string clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetBook", ReplyAction="http://tempuri.org/IStoreService/GetBookResponse")]
        StoreClient.StoreServiceReference.Book GetBook(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetBook", ReplyAction="http://tempuri.org/IStoreService/GetBookResponse")]
        System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Book> GetBookAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetOrders", ReplyAction="http://tempuri.org/IStoreService/GetOrdersResponse")]
        StoreClient.StoreServiceReference.Order[] GetOrders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetOrders", ReplyAction="http://tempuri.org/IStoreService/GetOrdersResponse")]
        System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Order[]> GetOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/CreateOrder", ReplyAction="http://tempuri.org/IStoreService/CreateOrderResponse")]
        StoreClient.StoreServiceReference.Order CreateOrder(int clientId, int bookId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/CreateOrder", ReplyAction="http://tempuri.org/IStoreService/CreateOrderResponse")]
        System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Order> CreateOrderAsync(int clientId, int bookId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/CreateClient", ReplyAction="http://tempuri.org/IStoreService/CreateClientResponse")]
        StoreClient.StoreServiceReference.Client CreateClient(string name, string address, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/CreateClient", ReplyAction="http://tempuri.org/IStoreService/CreateClientResponse")]
        System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Client> CreateClientAsync(string name, string address, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/NotifyFutureArrival", ReplyAction="http://tempuri.org/IStoreService/NotifyFutureArrivalResponse")]
        void NotifyFutureArrival(StoreClient.StoreServiceReference.Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/NotifyFutureArrival", ReplyAction="http://tempuri.org/IStoreService/NotifyFutureArrivalResponse")]
        System.Threading.Tasks.Task NotifyFutureArrivalAsync(StoreClient.StoreServiceReference.Request request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStoreServiceChannel : StoreClient.StoreServiceReference.IStoreService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StoreServiceClient : System.ServiceModel.ClientBase<StoreClient.StoreServiceReference.IStoreService>, StoreClient.StoreServiceReference.IStoreService {
        
        public StoreServiceClient() {
        }
        
        public StoreServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StoreServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StoreServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StoreServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public StoreClient.StoreServiceReference.Book[] GetBooks() {
            return base.Channel.GetBooks();
        }
        
        public System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Book[]> GetBooksAsync() {
            return base.Channel.GetBooksAsync();
        }
        
        public StoreClient.StoreServiceReference.Client[] GetClients() {
            return base.Channel.GetClients();
        }
        
        public System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Client[]> GetClientsAsync() {
            return base.Channel.GetClientsAsync();
        }
        
        public StoreClient.StoreServiceReference.Order[] GetClientOrders(string clientId) {
            return base.Channel.GetClientOrders(clientId);
        }
        
        public System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Order[]> GetClientOrdersAsync(string clientId) {
            return base.Channel.GetClientOrdersAsync(clientId);
        }
        
        public StoreClient.StoreServiceReference.Book GetBook(string id) {
            return base.Channel.GetBook(id);
        }
        
        public System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Book> GetBookAsync(string id) {
            return base.Channel.GetBookAsync(id);
        }
        
        public StoreClient.StoreServiceReference.Order[] GetOrders() {
            return base.Channel.GetOrders();
        }
        
        public System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Order[]> GetOrdersAsync() {
            return base.Channel.GetOrdersAsync();
        }
        
        public StoreClient.StoreServiceReference.Order CreateOrder(int clientId, int bookId, int quantity) {
            return base.Channel.CreateOrder(clientId, bookId, quantity);
        }
        
        public System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Order> CreateOrderAsync(int clientId, int bookId, int quantity) {
            return base.Channel.CreateOrderAsync(clientId, bookId, quantity);
        }
        
        public StoreClient.StoreServiceReference.Client CreateClient(string name, string address, string email) {
            return base.Channel.CreateClient(name, address, email);
        }
        
        public System.Threading.Tasks.Task<StoreClient.StoreServiceReference.Client> CreateClientAsync(string name, string address, string email) {
            return base.Channel.CreateClientAsync(name, address, email);
        }
        
        public void NotifyFutureArrival(StoreClient.StoreServiceReference.Request request) {
            base.Channel.NotifyFutureArrival(request);
        }
        
        public System.Threading.Tasks.Task NotifyFutureArrivalAsync(StoreClient.StoreServiceReference.Request request) {
            return base.Channel.NotifyFutureArrivalAsync(request);
        }
    }
}
