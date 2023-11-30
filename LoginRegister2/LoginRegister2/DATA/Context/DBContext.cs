using LoginRegister2.DATA.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoginRegister2.DATA.Context
{
    public class DBContext :IdentityDbContext<User>
    {
        public DBContext(DbContextOptions<DBContext> options):base (options) { } 
        public DbSet<Address> Addresses { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.HasDefaultSchema("Identity");

        //    builder.Entity<Address>()
        //        .HasOne(s => s.User)
        //        .WithMany(g => g.addresses)
        //        .HasForeignKey(s => s.UserId);
        //}
    }
}
