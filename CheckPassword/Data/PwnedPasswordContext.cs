using Microsoft.EntityFrameworkCore;
using CheckPassword.Models;

namespace CheckPassword.Data
{
    public class PwnedPasswordContext : DbContext
    {
        public PwnedPasswordContext(DbContextOptions<PwnedPasswordContext> options)
            : base(options)
        {
        }

        public DbSet<Password> Passwords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Password entity
            modelBuilder.Entity<Password>(entity =>
            {
                entity.ToTable("passwords");
                entity.HasKey(e => e.Hash);
                entity.Property(e => e.Hash)
                    .HasMaxLength(40) // SHA1 hash is 40 characters
                    .IsRequired();
            });
        }
    }
}
