﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wROJA.LinesService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Line", Namespace="http://schemas.datacontract.org/2004/07/wROJAServer.domain")]
    [System.SerializableAttribute()]
    public partial class Line : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RouteIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WayNameField;
        
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
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Number {
            get {
                return this.NumberField;
            }
            set {
                if ((object.ReferenceEquals(this.NumberField, value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RouteID {
            get {
                return this.RouteIDField;
            }
            set {
                if ((this.RouteIDField.Equals(value) != true)) {
                    this.RouteIDField = value;
                    this.RaisePropertyChanged("RouteID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WayName {
            get {
                return this.WayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.WayNameField, value) != true)) {
                    this.WayNameField = value;
                    this.RaisePropertyChanged("WayName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Stop", Namespace="http://schemas.datacontract.org/2004/07/wROJAServer.domain")]
    [System.SerializableAttribute()]
    public partial class Stop : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CommuneIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CommuneNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RouteDetailsIDField;
        
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
        public int CommuneID {
            get {
                return this.CommuneIDField;
            }
            set {
                if ((this.CommuneIDField.Equals(value) != true)) {
                    this.CommuneIDField = value;
                    this.RaisePropertyChanged("CommuneID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CommuneName {
            get {
                return this.CommuneNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CommuneNameField, value) != true)) {
                    this.CommuneNameField = value;
                    this.RaisePropertyChanged("CommuneName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LinesService.ILinesService")]
    public interface ILinesService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinesService/GetAllLines", ReplyAction="http://tempuri.org/ILinesService/GetAllLinesResponse")]
        wROJA.LinesService.Line[] GetAllLines();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinesService/GetAllLines", ReplyAction="http://tempuri.org/ILinesService/GetAllLinesResponse")]
        System.Threading.Tasks.Task<wROJA.LinesService.Line[]> GetAllLinesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinesService/GetStopsForLine", ReplyAction="http://tempuri.org/ILinesService/GetStopsForLineResponse")]
        wROJA.LinesService.Stop[] GetStopsForLine(int lineID, int routeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinesService/GetStopsForLine", ReplyAction="http://tempuri.org/ILinesService/GetStopsForLineResponse")]
        System.Threading.Tasks.Task<wROJA.LinesService.Stop[]> GetStopsForLineAsync(int lineID, int routeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinesService/GetTimetable", ReplyAction="http://tempuri.org/ILinesService/GetTimetableResponse")]
        wROJA.LinesService.Timetable[] GetTimetable(int routeDetailsID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinesService/GetTimetable", ReplyAction="http://tempuri.org/ILinesService/GetTimetableResponse")]
        System.Threading.Tasks.Task<wROJA.LinesService.Timetable[]> GetTimetableAsync(int routeDetailsID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILinesServiceChannel : wROJA.LinesService.ILinesService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LinesServiceClient : System.ServiceModel.ClientBase<wROJA.LinesService.ILinesService>, wROJA.LinesService.ILinesService {
        
        public LinesServiceClient() {
        }
        
        public LinesServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LinesServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LinesServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LinesServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public wROJA.LinesService.Line[] GetAllLines() {
            return base.Channel.GetAllLines();
        }
        
        public System.Threading.Tasks.Task<wROJA.LinesService.Line[]> GetAllLinesAsync() {
            return base.Channel.GetAllLinesAsync();
        }
        
        public wROJA.LinesService.Stop[] GetStopsForLine(int lineID, int routeID) {
            return base.Channel.GetStopsForLine(lineID, routeID);
        }
        
        public System.Threading.Tasks.Task<wROJA.LinesService.Stop[]> GetStopsForLineAsync(int lineID, int routeID) {
            return base.Channel.GetStopsForLineAsync(lineID, routeID);
        }
        
        public wROJA.LinesService.Timetable[] GetTimetable(int routeDetailsID) {
            return base.Channel.GetTimetable(routeDetailsID);
        }
        
        public System.Threading.Tasks.Task<wROJA.LinesService.Timetable[]> GetTimetableAsync(int routeDetailsID) {
            return base.Channel.GetTimetableAsync(routeDetailsID);
        }
    }
}
