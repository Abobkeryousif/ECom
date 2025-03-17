namespace Ecom.Core.Entities
{
    public class Address : BaseEntitiy<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }
        public string State { get; set; }

        public string UserAppId { get; set; }

        public virtual UserApp UserApp  { get; set; }
    }
}