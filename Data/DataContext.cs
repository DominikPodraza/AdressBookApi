using AdressBookApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdressBookApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Entry> Entries { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>(x => {
                x.HasKey(k => k.Id);
                x.Property(p => p.Id).ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
