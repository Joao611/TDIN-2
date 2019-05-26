﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreService.WarehouseServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
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
        private System.Guid orderGuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantityField;
        
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WarehouseServiceReference.IWarehouseQueueService")]
    public interface IWarehouseQueueService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWarehouseQueueService/RequestBooks")]
        void RequestBooks(string bookTitle, int quantity, System.Guid orderGuid);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWarehouseQueueService/RequestBooks")]
        System.Threading.Tasks.Task RequestBooksAsync(string bookTitle, int quantity, System.Guid orderGuid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWarehouseQueueServiceChannel : StoreService.WarehouseServiceReference.IWarehouseQueueService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WarehouseQueueServiceClient : System.ServiceModel.ClientBase<StoreService.WarehouseServiceReference.IWarehouseQueueService>, StoreService.WarehouseServiceReference.IWarehouseQueueService {
        
        public WarehouseQueueServiceClient() {
        }
        
        public WarehouseQueueServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WarehouseQueueServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WarehouseQueueServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WarehouseQueueServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void RequestBooks(string bookTitle, int quantity, System.Guid orderGuid) {
            base.Channel.RequestBooks(bookTitle, quantity, orderGuid);
        }
        
        public System.Threading.Tasks.Task RequestBooksAsync(string bookTitle, int quantity, System.Guid orderGuid) {
            return base.Channel.RequestBooksAsync(bookTitle, quantity, orderGuid);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WarehouseServiceReference.IWarehouseService", CallbackContract=typeof(StoreService.WarehouseServiceReference.IWarehouseServiceCallback))]
    public interface IWarehouseService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/Subscribe", ReplyAction="http://tempuri.org/IWarehouseService/SubscribeResponse")]
        void Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/Subscribe", ReplyAction="http://tempuri.org/IWarehouseService/SubscribeResponse")]
        System.Threading.Tasks.Task SubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/Unsubscribe", ReplyAction="http://tempuri.org/IWarehouseService/UnsubscribeResponse")]
        void Unsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/Unsubscribe", ReplyAction="http://tempuri.org/IWarehouseService/UnsubscribeResponse")]
        System.Threading.Tasks.Task UnsubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/GetRequests", ReplyAction="http://tempuri.org/IWarehouseService/GetRequestsResponse")]
        StoreService.WarehouseServiceReference.Request[] GetRequests();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/GetRequests", ReplyAction="http://tempuri.org/IWarehouseService/GetRequestsResponse")]
        System.Threading.Tasks.Task<StoreService.WarehouseServiceReference.Request[]> GetRequestsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/SendBooks", ReplyAction="http://tempuri.org/IWarehouseService/SendBooksResponse")]
        void SendBooks(string bookTitle, int quantity, System.Guid orderGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/SendBooks", ReplyAction="http://tempuri.org/IWarehouseService/SendBooksResponse")]
        System.Threading.Tasks.Task SendBooksAsync(string bookTitle, int quantity, System.Guid orderGuid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWarehouseServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWarehouseService/RequestCreated")]
        void RequestCreated(StoreService.WarehouseServiceReference.Request request);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWarehouseService/RequestStateUpdated")]
        void RequestStateUpdated(StoreService.WarehouseServiceReference.Request request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWarehouseServiceChannel : StoreService.WarehouseServiceReference.IWarehouseService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WarehouseServiceClient : System.ServiceModel.DuplexClientBase<StoreService.WarehouseServiceReference.IWarehouseService>, StoreService.WarehouseServiceReference.IWarehouseService {
        
        public WarehouseServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public WarehouseServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public WarehouseServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WarehouseServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WarehouseServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Subscribe() {
            base.Channel.Subscribe();
        }
        
        public System.Threading.Tasks.Task SubscribeAsync() {
            return base.Channel.SubscribeAsync();
        }
        
        public void Unsubscribe() {
            base.Channel.Unsubscribe();
        }
        
        public System.Threading.Tasks.Task UnsubscribeAsync() {
            return base.Channel.UnsubscribeAsync();
        }
        
        public StoreService.WarehouseServiceReference.Request[] GetRequests() {
            return base.Channel.GetRequests();
        }
        
        public System.Threading.Tasks.Task<StoreService.WarehouseServiceReference.Request[]> GetRequestsAsync() {
            return base.Channel.GetRequestsAsync();
        }
        
        public void SendBooks(string bookTitle, int quantity, System.Guid orderGuid) {
            base.Channel.SendBooks(bookTitle, quantity, orderGuid);
        }
        
        public System.Threading.Tasks.Task SendBooksAsync(string bookTitle, int quantity, System.Guid orderGuid) {
            return base.Channel.SendBooksAsync(bookTitle, quantity, orderGuid);
        }
    }
}
