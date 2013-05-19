﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wROJA.SearchService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RouteOptions", Namespace="http://schemas.datacontract.org/2004/07/wROJAServer.domain")]
    [System.SerializableAttribute()]
    public partial class RouteOptions : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RouteDetailsIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
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
        public int RouteDetailsID {
            get {
                return this.RouteDetailsIDField;
            }
            set {
                if ((this.RouteDetailsIDField.Equals(value) != true)) {
                    this.RouteDetailsIDField = value;
                    this.RaisePropertyChanged("RouteDetailsID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Timetable", Namespace="http://schemas.datacontract.org/2004/07/wROJAServer.domain")]
    [System.SerializableAttribute()]
    public partial class Timetable : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DayNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LegendField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TableField;
        
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
        public string DayName {
            get {
                return this.DayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DayNameField, value) != true)) {
                    this.DayNameField = value;
                    this.RaisePropertyChanged("DayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Legend {
            get {
                return this.LegendField;
            }
            set {
                if ((object.ReferenceEquals(this.LegendField, value) != true)) {
                    this.LegendField = value;
                    this.RaisePropertyChanged("Legend");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Table {
            get {
                return this.TableField;
            }
            set {
                if ((object.ReferenceEquals(this.TableField, value) != true)) {
                    this.TableField = value;
                    this.RaisePropertyChanged("Table");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SearchService.ISearchService")]
    public interface ISearchService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISearchService/GetStraightRoutes", ReplyAction="http://tempuri.org/ISearchService/GetStraightRoutesResponse")]
        wROJA.SearchService.RouteOptions[] GetStraightRoutes(int startStopID, int endStopID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISearchService/GetStraightRoutes", ReplyAction="http://tempuri.org/ISearchService/GetStraightRoutesResponse")]
        System.Threading.Tasks.Task<wROJA.SearchService.RouteOptions[]> GetStraightRoutesAsync(int startStopID, int endStopID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISearchService/GetTimetable", ReplyAction="http://tempuri.org/ISearchService/GetTimetableResponse")]
        wROJA.SearchService.Timetable[] GetTimetable(int routeDetailsID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISearchService/GetTimetable", ReplyAction="http://tempuri.org/ISearchService/GetTimetableResponse")]
        System.Threading.Tasks.Task<wROJA.SearchService.Timetable[]> GetTimetableAsync(int routeDetailsID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISearchServiceChannel : wROJA.SearchService.ISearchService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SearchServiceClient : System.ServiceModel.ClientBase<wROJA.SearchService.ISearchService>, wROJA.SearchService.ISearchService {
        
        public SearchServiceClient() {
        }
        
        public SearchServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SearchServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SearchServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SearchServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public wROJA.SearchService.RouteOptions[] GetStraightRoutes(int startStopID, int endStopID) {
            return base.Channel.GetStraightRoutes(startStopID, endStopID);
        }
        
        public System.Threading.Tasks.Task<wROJA.SearchService.RouteOptions[]> GetStraightRoutesAsync(int startStopID, int endStopID) {
            return base.Channel.GetStraightRoutesAsync(startStopID, endStopID);
        }
        
        public wROJA.SearchService.Timetable[] GetTimetable(int routeDetailsID) {
            return base.Channel.GetTimetable(routeDetailsID);
        }
        
        public System.Threading.Tasks.Task<wROJA.SearchService.Timetable[]> GetTimetableAsync(int routeDetailsID) {
            return base.Channel.GetTimetableAsync(routeDetailsID);
        }
    }
}