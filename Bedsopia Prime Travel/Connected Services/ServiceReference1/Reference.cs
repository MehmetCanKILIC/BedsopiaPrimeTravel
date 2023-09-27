﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bedsopia_Prime_Travel.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://juniper.es/", ConfigurationName="ServiceReference1.wsBookingsSoap")]
    public interface wsBookingsSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://juniper.es/getBookings", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode getBookings(
                    string user, 
                    string password, 
                    string BookingDateFrom, 
                    string BookingDateTo, 
                    string BookingTimeFrom, 
                    string BookingTimeTo, 
                    string BeginTravelDate, 
                    string EndTravelDate, 
                    string LastModifiedDateFrom, 
                    string LastModifiedDateTo, 
                    string LastModifiedTimeFrom, 
                    string LastModifiedTimeTo, 
                    string BookingCode, 
                    string Status, 
                    string id, 
                    string ExportMode, 
                    string channel, 
                    string ModuleType, 
                    string IdBooking, 
                    string AgencyRef, 
                    string BeginTravelDateFrom, 
                    string BeginTravelDateTo, 
                    string EndTravelDateFrom, 
                    string EndTravelDateTo, 
                    string PackageBookings, 
                    string BlockedBookings);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://juniper.es/getBookings", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> getBookingsAsync(
                    string user, 
                    string password, 
                    string BookingDateFrom, 
                    string BookingDateTo, 
                    string BookingTimeFrom, 
                    string BookingTimeTo, 
                    string BeginTravelDate, 
                    string EndTravelDate, 
                    string LastModifiedDateFrom, 
                    string LastModifiedDateTo, 
                    string LastModifiedTimeFrom, 
                    string LastModifiedTimeTo, 
                    string BookingCode, 
                    string Status, 
                    string id, 
                    string ExportMode, 
                    string channel, 
                    string ModuleType, 
                    string IdBooking, 
                    string AgencyRef, 
                    string BeginTravelDateFrom, 
                    string BeginTravelDateTo, 
                    string EndTravelDateFrom, 
                    string EndTravelDateTo, 
                    string PackageBookings, 
                    string BlockedBookings);
        
        // CODEGEN: Parameter 'NonRefundable' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://juniper.es/getBookingList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Bedsopia_Prime_Travel.ServiceReference1.getBookingListResponse getBookingList(Bedsopia_Prime_Travel.ServiceReference1.getBookingListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://juniper.es/getBookingList", ReplyAction="*")]
        System.Threading.Tasks.Task<Bedsopia_Prime_Travel.ServiceReference1.getBookingListResponse> getBookingListAsync(Bedsopia_Prime_Travel.ServiceReference1.getBookingListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://juniper.es/getSellIndirectCommissions", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode getSellIndirectCommissions(string user, string password, string CustomerID, string BookingCode, string BookingDateFrom, string BookingDateTo, string BeginTravelDateFrom, string BeginTravelDateTo, string EndTravelDateFrom, string EndTravelDateTo, string SettledStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://juniper.es/getSellIndirectCommissions", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> getSellIndirectCommissionsAsync(string user, string password, string CustomerID, string BookingCode, string BookingDateFrom, string BookingDateTo, string BeginTravelDateFrom, string BeginTravelDateTo, string EndTravelDateFrom, string EndTravelDateTo, string SettledStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://juniper.es/showModuleType", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode showModuleType(string user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://juniper.es/showModuleType", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> showModuleTypeAsync(string user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://juniper.es/setBookingDocuments", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode setBookingDocuments(string user, string password, string bookingCode, string lineBookingCode, string urlFile, string fileType, string descriptionFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://juniper.es/setBookingDocuments", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> setBookingDocumentsAsync(string user, string password, string bookingCode, string lineBookingCode, string urlFile, string fileType, string descriptionFile);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getBookingList", WrapperNamespace="http://juniper.es/", IsWrapped=true)]
    public partial class getBookingListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=0)]
        public string user;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=1)]
        public string password;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=2)]
        public string BookingDateFrom;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=3)]
        public string BookingDateTo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=4)]
        public string BookingTimeFrom;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=5)]
        public string BookingTimeTo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=6)]
        public string BeginTravelDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=7)]
        public string EndTravelDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=8)]
        public string LastModifiedDateFrom;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=9)]
        public string LastModifiedDateTo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=10)]
        public string LastModifiedTimeFrom;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=11)]
        public string LastModifiedTimeTo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=12)]
        public string Status;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=13)]
        public string id;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=14)]
        public string channel;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=15)]
        public string ModuleType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=16)]
        public string BeginTravelDateFrom;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=17)]
        public string BeginTravelDateTo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=18)]
        public string EndTravelDateFrom;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=19)]
        public string EndTravelDateTo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=20)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> NonRefundable;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=21)]
        public string PackageBookings;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=22)]
        public string BlockedBookings;
        
        public getBookingListRequest() {
        }
        
        public getBookingListRequest(
                    string user, 
                    string password, 
                    string BookingDateFrom, 
                    string BookingDateTo, 
                    string BookingTimeFrom, 
                    string BookingTimeTo, 
                    string BeginTravelDate, 
                    string EndTravelDate, 
                    string LastModifiedDateFrom, 
                    string LastModifiedDateTo, 
                    string LastModifiedTimeFrom, 
                    string LastModifiedTimeTo, 
                    string Status, 
                    string id, 
                    string channel, 
                    string ModuleType, 
                    string BeginTravelDateFrom, 
                    string BeginTravelDateTo, 
                    string EndTravelDateFrom, 
                    string EndTravelDateTo, 
                    System.Nullable<bool> NonRefundable, 
                    string PackageBookings, 
                    string BlockedBookings) {
            this.user = user;
            this.password = password;
            this.BookingDateFrom = BookingDateFrom;
            this.BookingDateTo = BookingDateTo;
            this.BookingTimeFrom = BookingTimeFrom;
            this.BookingTimeTo = BookingTimeTo;
            this.BeginTravelDate = BeginTravelDate;
            this.EndTravelDate = EndTravelDate;
            this.LastModifiedDateFrom = LastModifiedDateFrom;
            this.LastModifiedDateTo = LastModifiedDateTo;
            this.LastModifiedTimeFrom = LastModifiedTimeFrom;
            this.LastModifiedTimeTo = LastModifiedTimeTo;
            this.Status = Status;
            this.id = id;
            this.channel = channel;
            this.ModuleType = ModuleType;
            this.BeginTravelDateFrom = BeginTravelDateFrom;
            this.BeginTravelDateTo = BeginTravelDateTo;
            this.EndTravelDateFrom = EndTravelDateFrom;
            this.EndTravelDateTo = EndTravelDateTo;
            this.NonRefundable = NonRefundable;
            this.PackageBookings = PackageBookings;
            this.BlockedBookings = BlockedBookings;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getBookingListResponse", WrapperNamespace="http://juniper.es/", IsWrapped=true)]
    public partial class getBookingListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://juniper.es/", Order=0)]
        public System.Xml.XmlNode getBookingListResult;
        
        public getBookingListResponse() {
        }
        
        public getBookingListResponse(System.Xml.XmlNode getBookingListResult) {
            this.getBookingListResult = getBookingListResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface wsBookingsSoapChannel : Bedsopia_Prime_Travel.ServiceReference1.wsBookingsSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class wsBookingsSoapClient : System.ServiceModel.ClientBase<Bedsopia_Prime_Travel.ServiceReference1.wsBookingsSoap>, Bedsopia_Prime_Travel.ServiceReference1.wsBookingsSoap {
        
        public wsBookingsSoapClient() {
        }
        
        public wsBookingsSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public wsBookingsSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public wsBookingsSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public wsBookingsSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Xml.XmlNode getBookings(
                    string user, 
                    string password, 
                    string BookingDateFrom, 
                    string BookingDateTo, 
                    string BookingTimeFrom, 
                    string BookingTimeTo, 
                    string BeginTravelDate, 
                    string EndTravelDate, 
                    string LastModifiedDateFrom, 
                    string LastModifiedDateTo, 
                    string LastModifiedTimeFrom, 
                    string LastModifiedTimeTo, 
                    string BookingCode, 
                    string Status, 
                    string id, 
                    string ExportMode, 
                    string channel, 
                    string ModuleType, 
                    string IdBooking, 
                    string AgencyRef, 
                    string BeginTravelDateFrom, 
                    string BeginTravelDateTo, 
                    string EndTravelDateFrom, 
                    string EndTravelDateTo, 
                    string PackageBookings, 
                    string BlockedBookings) {
            return base.Channel.getBookings(user, password, BookingDateFrom, BookingDateTo, BookingTimeFrom, BookingTimeTo, BeginTravelDate, EndTravelDate, LastModifiedDateFrom, LastModifiedDateTo, LastModifiedTimeFrom, LastModifiedTimeTo, BookingCode, Status, id, ExportMode, channel, ModuleType, IdBooking, AgencyRef, BeginTravelDateFrom, BeginTravelDateTo, EndTravelDateFrom, EndTravelDateTo, PackageBookings, BlockedBookings);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> getBookingsAsync(
                    string user, 
                    string password, 
                    string BookingDateFrom, 
                    string BookingDateTo, 
                    string BookingTimeFrom, 
                    string BookingTimeTo, 
                    string BeginTravelDate, 
                    string EndTravelDate, 
                    string LastModifiedDateFrom, 
                    string LastModifiedDateTo, 
                    string LastModifiedTimeFrom, 
                    string LastModifiedTimeTo, 
                    string BookingCode, 
                    string Status, 
                    string id, 
                    string ExportMode, 
                    string channel, 
                    string ModuleType, 
                    string IdBooking, 
                    string AgencyRef, 
                    string BeginTravelDateFrom, 
                    string BeginTravelDateTo, 
                    string EndTravelDateFrom, 
                    string EndTravelDateTo, 
                    string PackageBookings, 
                    string BlockedBookings) {
            return base.Channel.getBookingsAsync(user, password, BookingDateFrom, BookingDateTo, BookingTimeFrom, BookingTimeTo, BeginTravelDate, EndTravelDate, LastModifiedDateFrom, LastModifiedDateTo, LastModifiedTimeFrom, LastModifiedTimeTo, BookingCode, Status, id, ExportMode, channel, ModuleType, IdBooking, AgencyRef, BeginTravelDateFrom, BeginTravelDateTo, EndTravelDateFrom, EndTravelDateTo, PackageBookings, BlockedBookings);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Bedsopia_Prime_Travel.ServiceReference1.getBookingListResponse Bedsopia_Prime_Travel.ServiceReference1.wsBookingsSoap.getBookingList(Bedsopia_Prime_Travel.ServiceReference1.getBookingListRequest request) {
            return base.Channel.getBookingList(request);
        }
        
        public System.Xml.XmlNode getBookingList(
                    string user, 
                    string password, 
                    string BookingDateFrom, 
                    string BookingDateTo, 
                    string BookingTimeFrom, 
                    string BookingTimeTo, 
                    string BeginTravelDate, 
                    string EndTravelDate, 
                    string LastModifiedDateFrom, 
                    string LastModifiedDateTo, 
                    string LastModifiedTimeFrom, 
                    string LastModifiedTimeTo, 
                    string Status, 
                    string id, 
                    string channel, 
                    string ModuleType, 
                    string BeginTravelDateFrom, 
                    string BeginTravelDateTo, 
                    string EndTravelDateFrom, 
                    string EndTravelDateTo, 
                    System.Nullable<bool> NonRefundable, 
                    string PackageBookings, 
                    string BlockedBookings) {
            Bedsopia_Prime_Travel.ServiceReference1.getBookingListRequest inValue = new Bedsopia_Prime_Travel.ServiceReference1.getBookingListRequest();
            inValue.user = user;
            inValue.password = password;
            inValue.BookingDateFrom = BookingDateFrom;
            inValue.BookingDateTo = BookingDateTo;
            inValue.BookingTimeFrom = BookingTimeFrom;
            inValue.BookingTimeTo = BookingTimeTo;
            inValue.BeginTravelDate = BeginTravelDate;
            inValue.EndTravelDate = EndTravelDate;
            inValue.LastModifiedDateFrom = LastModifiedDateFrom;
            inValue.LastModifiedDateTo = LastModifiedDateTo;
            inValue.LastModifiedTimeFrom = LastModifiedTimeFrom;
            inValue.LastModifiedTimeTo = LastModifiedTimeTo;
            inValue.Status = Status;
            inValue.id = id;
            inValue.channel = channel;
            inValue.ModuleType = ModuleType;
            inValue.BeginTravelDateFrom = BeginTravelDateFrom;
            inValue.BeginTravelDateTo = BeginTravelDateTo;
            inValue.EndTravelDateFrom = EndTravelDateFrom;
            inValue.EndTravelDateTo = EndTravelDateTo;
            inValue.NonRefundable = NonRefundable;
            inValue.PackageBookings = PackageBookings;
            inValue.BlockedBookings = BlockedBookings;
            Bedsopia_Prime_Travel.ServiceReference1.getBookingListResponse retVal = ((Bedsopia_Prime_Travel.ServiceReference1.wsBookingsSoap)(this)).getBookingList(inValue);
            return retVal.getBookingListResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Bedsopia_Prime_Travel.ServiceReference1.getBookingListResponse> Bedsopia_Prime_Travel.ServiceReference1.wsBookingsSoap.getBookingListAsync(Bedsopia_Prime_Travel.ServiceReference1.getBookingListRequest request) {
            return base.Channel.getBookingListAsync(request);
        }
        
        public System.Threading.Tasks.Task<Bedsopia_Prime_Travel.ServiceReference1.getBookingListResponse> getBookingListAsync(
                    string user, 
                    string password, 
                    string BookingDateFrom, 
                    string BookingDateTo, 
                    string BookingTimeFrom, 
                    string BookingTimeTo, 
                    string BeginTravelDate, 
                    string EndTravelDate, 
                    string LastModifiedDateFrom, 
                    string LastModifiedDateTo, 
                    string LastModifiedTimeFrom, 
                    string LastModifiedTimeTo, 
                    string Status, 
                    string id, 
                    string channel, 
                    string ModuleType, 
                    string BeginTravelDateFrom, 
                    string BeginTravelDateTo, 
                    string EndTravelDateFrom, 
                    string EndTravelDateTo, 
                    System.Nullable<bool> NonRefundable, 
                    string PackageBookings, 
                    string BlockedBookings) {
            Bedsopia_Prime_Travel.ServiceReference1.getBookingListRequest inValue = new Bedsopia_Prime_Travel.ServiceReference1.getBookingListRequest();
            inValue.user = user;
            inValue.password = password;
            inValue.BookingDateFrom = BookingDateFrom;
            inValue.BookingDateTo = BookingDateTo;
            inValue.BookingTimeFrom = BookingTimeFrom;
            inValue.BookingTimeTo = BookingTimeTo;
            inValue.BeginTravelDate = BeginTravelDate;
            inValue.EndTravelDate = EndTravelDate;
            inValue.LastModifiedDateFrom = LastModifiedDateFrom;
            inValue.LastModifiedDateTo = LastModifiedDateTo;
            inValue.LastModifiedTimeFrom = LastModifiedTimeFrom;
            inValue.LastModifiedTimeTo = LastModifiedTimeTo;
            inValue.Status = Status;
            inValue.id = id;
            inValue.channel = channel;
            inValue.ModuleType = ModuleType;
            inValue.BeginTravelDateFrom = BeginTravelDateFrom;
            inValue.BeginTravelDateTo = BeginTravelDateTo;
            inValue.EndTravelDateFrom = EndTravelDateFrom;
            inValue.EndTravelDateTo = EndTravelDateTo;
            inValue.NonRefundable = NonRefundable;
            inValue.PackageBookings = PackageBookings;
            inValue.BlockedBookings = BlockedBookings;
            return ((Bedsopia_Prime_Travel.ServiceReference1.wsBookingsSoap)(this)).getBookingListAsync(inValue);
        }
        
        public System.Xml.XmlNode getSellIndirectCommissions(string user, string password, string CustomerID, string BookingCode, string BookingDateFrom, string BookingDateTo, string BeginTravelDateFrom, string BeginTravelDateTo, string EndTravelDateFrom, string EndTravelDateTo, string SettledStatus) {
            return base.Channel.getSellIndirectCommissions(user, password, CustomerID, BookingCode, BookingDateFrom, BookingDateTo, BeginTravelDateFrom, BeginTravelDateTo, EndTravelDateFrom, EndTravelDateTo, SettledStatus);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> getSellIndirectCommissionsAsync(string user, string password, string CustomerID, string BookingCode, string BookingDateFrom, string BookingDateTo, string BeginTravelDateFrom, string BeginTravelDateTo, string EndTravelDateFrom, string EndTravelDateTo, string SettledStatus) {
            return base.Channel.getSellIndirectCommissionsAsync(user, password, CustomerID, BookingCode, BookingDateFrom, BookingDateTo, BeginTravelDateFrom, BeginTravelDateTo, EndTravelDateFrom, EndTravelDateTo, SettledStatus);
        }
        
        public System.Xml.XmlNode showModuleType(string user, string password) {
            return base.Channel.showModuleType(user, password);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> showModuleTypeAsync(string user, string password) {
            return base.Channel.showModuleTypeAsync(user, password);
        }
        
        public System.Xml.XmlNode setBookingDocuments(string user, string password, string bookingCode, string lineBookingCode, string urlFile, string fileType, string descriptionFile) {
            return base.Channel.setBookingDocuments(user, password, bookingCode, lineBookingCode, urlFile, fileType, descriptionFile);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> setBookingDocumentsAsync(string user, string password, string bookingCode, string lineBookingCode, string urlFile, string fileType, string descriptionFile) {
            return base.Channel.setBookingDocumentsAsync(user, password, bookingCode, lineBookingCode, urlFile, fileType, descriptionFile);
        }
    }
}