using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure
{
    public class ApplicationDbContext:DbContext,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customers> Customers => Set<Customers>();
        public DbSet<CustomerProducts> CustomersProducts => Set<CustomerProducts>();

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<User>()
                .HasKey(x => x.Id); 
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(i => i.IsActive)
                .HasDefaultValue(1);

            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Product>()
                .HasIndex(x=>x.ProductCode)
                .IsUnique();    

            modelBuilder.Entity<User>()
                .HasMany(p=>p.Products)
                .WithOne(u=>u.User)
                .HasForeignKey(u=>u.UserId);

            modelBuilder.Entity<Customers>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Customers>()
                .HasIndex(e=>e.Email)
                .IsUnique();
            modelBuilder.Entity<Customers>()
                .HasMany(p => p.CustomerProducts)
                .WithOne(c => c.Customers)
                .HasForeignKey(i => i.CustomerId);

            modelBuilder.Entity<CustomerProducts>()
                .HasKey(p => p.ProductId);

        }
    }
}