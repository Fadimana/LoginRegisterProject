namespace SchoolAPI.Data.Entity
{
    public class Fakülte
    {
        public int Id { get; set; }
        public string? FakülteName { get; set; }
        public int BolumId { get; set; }
        public Bölüm Bölüm { get; set; }
    }
}
