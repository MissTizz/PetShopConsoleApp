using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data
{
    public class PetShopAppContext : DbContext
    { 
        public PetShopAppContext(DbContextOptions<PetShopAppContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.PreviousOwner)
                .WithMany(o => o.Pets)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}
