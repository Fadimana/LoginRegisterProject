using System.Text.Json.Serialization;

namespace LoginRegister2.DATA.Model
{
    public class Address
    {
        public int Id { get; set; } 
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string ApartmanName { get; set; }
        public bool Control {  get; set; }
        public string UserId { get; set; }
    }
}
