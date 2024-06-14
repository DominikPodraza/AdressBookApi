using AdressBook.Domain.Entities;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdressBook.Infrastructure.Persistence
{
    internal class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Entry> Entries { get; set; } = null!;
        public DbSet<PhoneNumber>? NumberPhones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>(x =>
            {
                x.HasKey(k => k.Id);
                x.HasIndex(x => x.Nick).IsUnique();
                x.Property(p => p.Id).ValueGeneratedOnAdd();
                x.HasMany(y => y.NumberPhones)
                    .WithOne(y => y.Entry)
                    .HasForeignKey(y => y.EntryId)
                    .HasPrincipalKey(y => y.Id);
            });
            modelBuilder.Entity<PhoneNumber>(x =>
            {
                x.HasKey(k => k.NumberPhoneId);

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
