using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Entity;

namespace SchoolAPI.Data.Context
{
    public class SchoolDbContext :DbContext
    {
        public DbSet<Bölüm> Bölümler { get; set; }
        public DbSet<Fakülte> Fakülteler { get;set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) :base(options) { }
    }
}
