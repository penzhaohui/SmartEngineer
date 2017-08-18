using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.ServiceClient.Models
{

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Account", Namespace = "http://schemas.datacontract.org/2004/07/SmartEngineer.Service.Model")]
    [System.SerializableAttribute()]
    public partial class Account : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccessTokenField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailAddressField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SmartEngineer.ServiceClient.Models.Tenant[] TenantsField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AccessToken
        {
            get
            {
                return this.AccessTokenField;
            }
            set
            {
                if ((object.ReferenceEquals(this.AccessTokenField, value) != true))
                {
                    this.AccessTokenField = value;
                    this.RaisePropertyChanged("AccessToken");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DisplayName
        {
            get
            {
                return this.DisplayNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DisplayNameField, value) != true))
                {
                    this.DisplayNameField = value;
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmailAddress
        {
            get
            {
                return this.EmailAddressField;
            }
            set
            {
                if ((object.ReferenceEquals(this.EmailAddressField, value) != true))
                {
                    this.EmailAddressField = value;
                    this.RaisePropertyChanged("EmailAddress");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID
        {
            get
            {
                return this.IDField;
            }
            set
            {
                if ((this.IDField.Equals(value) != true))
                {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password
        {
            get
            {
                return this.PasswordField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PasswordField, value) != true))
                {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public SmartEngineer.ServiceClient.Models.Tenant[] Tenants
        {
            get
            {
                return this.TenantsField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TenantsField, value) != true))
                {
                    this.TenantsField = value;
                    this.RaisePropertyChanged("Tenants");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName
        {
            get
            {
                return this.UserNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.UserNameField, value) != true))
                {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
