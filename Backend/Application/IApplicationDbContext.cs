using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; }
        public DbSet<Product> Products { get; }
        public DbSet<Customers> Customers { get; }
        public DbSet<CustomerProducts> CustomersProducts { get; }   
        Task SaveChangesAsync();
    }
}