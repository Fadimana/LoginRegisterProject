namespace SchoolAPI.Data.Entity
{
    public class Bölüm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Fakülte> Fakülteler { get; set; }
    }
}
