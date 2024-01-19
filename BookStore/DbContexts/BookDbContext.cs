using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DbContexts
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=sumit;user=root;password=root123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(Entity =>
            {
                Entity.HasKey(e => e.Id);
                Entity.Property(e => e.Title);
                Entity.Property(e => e.Author);
                Entity.Property(e => e.Price);
                Entity.Property(e => e.Qunatity);
            });
        }
    }
}
