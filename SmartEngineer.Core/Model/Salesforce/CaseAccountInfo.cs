using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class CaseAccountInfo : BasicDataModel
    {
        public void Initialize(AccelaCaseAccount accelaCaseAccount)
        {
            this.Name = accelaCaseAccount.Name;
            this.Email = accelaCaseAccount.Email;
            this.FirstName = accelaCaseAccount.FirstName;
            this.LastName = accelaCaseAccount.LastName;
            this.IsActive = accelaCaseAccount.IsActive;
            this.UserID = accelaCaseAccount.Id;
            this.Phone = accelaCaseAccount.Phone;
            this.MobilePhone = accelaCaseAccount.MobilePhone;
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string MobilePhone { get; set; }
    }
}
