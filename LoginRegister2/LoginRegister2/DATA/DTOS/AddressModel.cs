namespace LoginRegister2.DATA.DTOS
{
    public class AddressModel
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }

        public string? PostalCode { get; set; }
        public string? ApartmanName { get; set; }

        public Guid ? UserId { get; set; }
    }
}
