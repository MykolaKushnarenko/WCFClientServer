﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.CodeCompare {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddingCodeObject", Namespace="http://schemas.datacontract.org/2004/07/Service.DateObjectSender")]
    [System.SerializableAttribute()]
    public partial class AddingCodeObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CompareLocalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CompileTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FileManeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsAllAnalysisField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSearchField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] SolutionField;
        
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
        public byte[] Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool CompareLocal {
            get {
                return this.CompareLocalField;
            }
            set {
                if ((this.CompareLocalField.Equals(value) != true)) {
                    this.CompareLocalField = value;
                    this.RaisePropertyChanged("CompareLocal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CompileType {
            get {
                return this.CompileTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.CompileTypeField, value) != true)) {
                    this.CompileTypeField = value;
                    this.RaisePropertyChanged("CompileType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileMane {
            get {
                return this.FileManeField;
            }
            set {
                if ((object.ReferenceEquals(this.FileManeField, value) != true)) {
                    this.FileManeField = value;
                    this.RaisePropertyChanged("FileMane");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsAllAnalysis {
            get {
                return this.IsAllAnalysisField;
            }
            set {
                if ((this.IsAllAnalysisField.Equals(value) != true)) {
                    this.IsAllAnalysisField = value;
                    this.RaisePropertyChanged("IsAllAnalysis");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSearch {
            get {
                return this.IsSearchField;
            }
            set {
                if ((this.IsSearchField.Equals(value) != true)) {
                    this.IsSearchField = value;
                    this.RaisePropertyChanged("IsSearch");
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
        public byte[] Solution {
            get {
                return this.SolutionField;
            }
            set {
                if ((object.ReferenceEquals(this.SolutionField, value) != true)) {
                    this.SolutionField = value;
                    this.RaisePropertyChanged("Solution");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ResultCompareObject", Namespace="http://schemas.datacontract.org/2004/07/Service.DateObjectSender")]
    [System.SerializableAttribute()]
    public partial class ResultCompareObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ChildCodeTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.CodeCompare.DAnalysClassObject[] DeteilAnalysRoslynField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsLocalCompareField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MainCodeTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ResultCompareField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] TokkingChildCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] TokkingMainCodeField;
        
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
        public string ChildCodeText {
            get {
                return this.ChildCodeTextField;
            }
            set {
                if ((object.ReferenceEquals(this.ChildCodeTextField, value) != true)) {
                    this.ChildCodeTextField = value;
                    this.RaisePropertyChanged("ChildCodeText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Client.CodeCompare.DAnalysClassObject[] DeteilAnalysRoslyn {
            get {
                return this.DeteilAnalysRoslynField;
            }
            set {
                if ((object.ReferenceEquals(this.DeteilAnalysRoslynField, value) != true)) {
                    this.DeteilAnalysRoslynField = value;
                    this.RaisePropertyChanged("DeteilAnalysRoslyn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsLocalCompare {
            get {
                return this.IsLocalCompareField;
            }
            set {
                if ((this.IsLocalCompareField.Equals(value) != true)) {
                    this.IsLocalCompareField = value;
                    this.RaisePropertyChanged("IsLocalCompare");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MainCodeText {
            get {
                return this.MainCodeTextField;
            }
            set {
                if ((object.ReferenceEquals(this.MainCodeTextField, value) != true)) {
                    this.MainCodeTextField = value;
                    this.RaisePropertyChanged("MainCodeText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] ResultCompare {
            get {
                return this.ResultCompareField;
            }
            set {
                if ((object.ReferenceEquals(this.ResultCompareField, value) != true)) {
                    this.ResultCompareField = value;
                    this.RaisePropertyChanged("ResultCompare");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] TokkingChildCode {
            get {
                return this.TokkingChildCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.TokkingChildCodeField, value) != true)) {
                    this.TokkingChildCodeField = value;
                    this.RaisePropertyChanged("TokkingChildCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] TokkingMainCode {
            get {
                return this.TokkingMainCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.TokkingMainCodeField, value) != true)) {
                    this.TokkingMainCodeField = value;
                    this.RaisePropertyChanged("TokkingMainCode");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DAnalysClassObject", Namespace="http://schemas.datacontract.org/2004/07/Service.DateObjectSender.DetailAnalyz")]
    [System.SerializableAttribute()]
    public partial class DAnalysClassObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.CodeCompare.DAnalysMethodObject[] AllMethodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BaseClassesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClassNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CountOfMehodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ErrorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool HasErrorField;
        
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
        public Client.CodeCompare.DAnalysMethodObject[] AllMethod {
            get {
                return this.AllMethodField;
            }
            set {
                if ((object.ReferenceEquals(this.AllMethodField, value) != true)) {
                    this.AllMethodField = value;
                    this.RaisePropertyChanged("AllMethod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BaseClasses {
            get {
                return this.BaseClassesField;
            }
            set {
                if ((object.ReferenceEquals(this.BaseClassesField, value) != true)) {
                    this.BaseClassesField = value;
                    this.RaisePropertyChanged("BaseClasses");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClassName {
            get {
                return this.ClassNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ClassNameField, value) != true)) {
                    this.ClassNameField = value;
                    this.RaisePropertyChanged("ClassName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CountOfMehod {
            get {
                return this.CountOfMehodField;
            }
            set {
                if ((this.CountOfMehodField.Equals(value) != true)) {
                    this.CountOfMehodField = value;
                    this.RaisePropertyChanged("CountOfMehod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Error {
            get {
                return this.ErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorField, value) != true)) {
                    this.ErrorField = value;
                    this.RaisePropertyChanged("Error");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool HasError {
            get {
                return this.HasErrorField;
            }
            set {
                if ((this.HasErrorField.Equals(value) != true)) {
                    this.HasErrorField = value;
                    this.RaisePropertyChanged("HasError");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DAnalysMethodObject", Namespace="http://schemas.datacontract.org/2004/07/Service.DateObjectSender.DetailAnalyz")]
    [System.SerializableAttribute()]
    public partial class DAnalysMethodObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] AllTypeInMethodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string[] AllTypeInMethod {
            get {
                return this.AllTypeInMethodField;
            }
            set {
                if ((object.ReferenceEquals(this.AllTypeInMethodField, value) != true)) {
                    this.AllTypeInMethodField = value;
                    this.RaisePropertyChanged("AllTypeInMethod");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="RegistrationObject", Namespace="http://schemas.datacontract.org/2004/07/Service.DateObjectSender")]
    [System.SerializableAttribute()]
    public partial class RegistrationObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EMailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
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
        public string EMail {
            get {
                return this.EMailField;
            }
            set {
                if ((object.ReferenceEquals(this.EMailField, value) != true)) {
                    this.EMailField = value;
                    this.RaisePropertyChanged("EMail");
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
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="UserInformationObject", Namespace="http://schemas.datacontract.org/2004/07/Service.DateObjectSender")]
    [System.SerializableAttribute()]
    public partial class UserInformationObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ImageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
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
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Image {
            get {
                return this.ImageField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageField, value) != true)) {
                    this.ImageField = value;
                    this.RaisePropertyChanged("Image");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
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
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CodeCompare.IServiceContract")]
    public interface IServiceContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/GetData", ReplyAction="http://tempuri.org/IServiceContract/GetDataResponse")]
        string GetData(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/GetData", ReplyAction="http://tempuri.org/IServiceContract/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/GetComipeType", ReplyAction="http://tempuri.org/IServiceContract/GetComipeTypeResponse")]
        string[] GetComipeType(string lang);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/GetComipeType", ReplyAction="http://tempuri.org/IServiceContract/GetComipeTypeResponse")]
        System.Threading.Tasks.Task<string[]> GetComipeTypeAsync(string lang);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/AddCode", ReplyAction="http://tempuri.org/IServiceContract/AddCodeResponse")]
        Client.CodeCompare.ResultCompareObject AddCode(Client.CodeCompare.AddingCodeObject param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/AddCode", ReplyAction="http://tempuri.org/IServiceContract/AddCodeResponse")]
        System.Threading.Tasks.Task<Client.CodeCompare.ResultCompareObject> AddCodeAsync(Client.CodeCompare.AddingCodeObject param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/GetListSubmit", ReplyAction="http://tempuri.org/IServiceContract/GetListSubmitResponse")]
        string[] GetListSubmit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/GetListSubmit", ReplyAction="http://tempuri.org/IServiceContract/GetListSubmitResponse")]
        System.Threading.Tasks.Task<string[]> GetListSubmitAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/SearchFromListSubmit", ReplyAction="http://tempuri.org/IServiceContract/SearchFromListSubmitResponse")]
        Client.CodeCompare.ResultCompareObject SearchFromListSubmit(string tagForSearch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/SearchFromListSubmit", ReplyAction="http://tempuri.org/IServiceContract/SearchFromListSubmitResponse")]
        System.Threading.Tasks.Task<Client.CodeCompare.ResultCompareObject> SearchFromListSubmitAsync(string tagForSearch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/GetListHistory", ReplyAction="http://tempuri.org/IServiceContract/GetListHistoryResponse")]
        string[] GetListHistory();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/GetListHistory", ReplyAction="http://tempuri.org/IServiceContract/GetListHistoryResponse")]
        System.Threading.Tasks.Task<string[]> GetListHistoryAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/Registration", ReplyAction="http://tempuri.org/IServiceContract/RegistrationResponse")]
        bool Registration(Client.CodeCompare.RegistrationObject regInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/Registration", ReplyAction="http://tempuri.org/IServiceContract/RegistrationResponse")]
        System.Threading.Tasks.Task<bool> RegistrationAsync(Client.CodeCompare.RegistrationObject regInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/Autification", ReplyAction="http://tempuri.org/IServiceContract/AutificationResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Client.CodeCompare.AddingCodeObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Client.CodeCompare.ResultCompareObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Client.CodeCompare.RegistrationObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Client.CodeCompare.UserInformationObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Client.CodeCompare.DAnalysClassObject[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Client.CodeCompare.DAnalysClassObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Client.CodeCompare.DAnalysMethodObject[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Client.CodeCompare.DAnalysMethodObject))]
        object[] Autification(Client.CodeCompare.UserInformationObject information);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/Autification", ReplyAction="http://tempuri.org/IServiceContract/AutificationResponse")]
        System.Threading.Tasks.Task<object[]> AutificationAsync(Client.CodeCompare.UserInformationObject information);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ChangeUserImage", ReplyAction="http://tempuri.org/IServiceContract/ChangeUserImageResponse")]
        bool ChangeUserImage(Client.CodeCompare.UserInformationObject information);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ChangeUserImage", ReplyAction="http://tempuri.org/IServiceContract/ChangeUserImageResponse")]
        System.Threading.Tasks.Task<bool> ChangeUserImageAsync(Client.CodeCompare.UserInformationObject information);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/UpdateUserInfo", ReplyAction="http://tempuri.org/IServiceContract/UpdateUserInfoResponse")]
        void UpdateUserInfo(Client.CodeCompare.UserInformationObject information);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/UpdateUserInfo", ReplyAction="http://tempuri.org/IServiceContract/UpdateUserInfoResponse")]
        System.Threading.Tasks.Task UpdateUserInfoAsync(Client.CodeCompare.UserInformationObject information);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceContractChannel : Client.CodeCompare.IServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceContractClient : System.ServiceModel.ClientBase<Client.CodeCompare.IServiceContract>, Client.CodeCompare.IServiceContract {
        
        public ServiceContractClient() {
        }
        
        public ServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(string value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(string value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public string[] GetComipeType(string lang) {
            return base.Channel.GetComipeType(lang);
        }
        
        public System.Threading.Tasks.Task<string[]> GetComipeTypeAsync(string lang) {
            return base.Channel.GetComipeTypeAsync(lang);
        }
        
        public Client.CodeCompare.ResultCompareObject AddCode(Client.CodeCompare.AddingCodeObject param) {
            return base.Channel.AddCode(param);
        }
        
        public System.Threading.Tasks.Task<Client.CodeCompare.ResultCompareObject> AddCodeAsync(Client.CodeCompare.AddingCodeObject param) {
            return base.Channel.AddCodeAsync(param);
        }
        
        public string[] GetListSubmit() {
            return base.Channel.GetListSubmit();
        }
        
        public System.Threading.Tasks.Task<string[]> GetListSubmitAsync() {
            return base.Channel.GetListSubmitAsync();
        }
        
        public Client.CodeCompare.ResultCompareObject SearchFromListSubmit(string tagForSearch) {
            return base.Channel.SearchFromListSubmit(tagForSearch);
        }
        
        public System.Threading.Tasks.Task<Client.CodeCompare.ResultCompareObject> SearchFromListSubmitAsync(string tagForSearch) {
            return base.Channel.SearchFromListSubmitAsync(tagForSearch);
        }
        
        public string[] GetListHistory() {
            return base.Channel.GetListHistory();
        }
        
        public System.Threading.Tasks.Task<string[]> GetListHistoryAsync() {
            return base.Channel.GetListHistoryAsync();
        }
        
        public bool Registration(Client.CodeCompare.RegistrationObject regInfo) {
            return base.Channel.Registration(regInfo);
        }
        
        public System.Threading.Tasks.Task<bool> RegistrationAsync(Client.CodeCompare.RegistrationObject regInfo) {
            return base.Channel.RegistrationAsync(regInfo);
        }
        
        public object[] Autification(Client.CodeCompare.UserInformationObject information) {
            return base.Channel.Autification(information);
        }
        
        public System.Threading.Tasks.Task<object[]> AutificationAsync(Client.CodeCompare.UserInformationObject information) {
            return base.Channel.AutificationAsync(information);
        }
        
        public bool ChangeUserImage(Client.CodeCompare.UserInformationObject information) {
            return base.Channel.ChangeUserImage(information);
        }
        
        public System.Threading.Tasks.Task<bool> ChangeUserImageAsync(Client.CodeCompare.UserInformationObject information) {
            return base.Channel.ChangeUserImageAsync(information);
        }
        
        public void UpdateUserInfo(Client.CodeCompare.UserInformationObject information) {
            base.Channel.UpdateUserInfo(information);
        }
        
        public System.Threading.Tasks.Task UpdateUserInfoAsync(Client.CodeCompare.UserInformationObject information) {
            return base.Channel.UpdateUserInfoAsync(information);
        }
    }
}
