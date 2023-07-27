using Microsoft.EntityFrameworkCore;
using Waterworks.DTO;

namespace Waterworks.DB
{
    public class ConnectMssql : DbContext
    {
        public ConnectMssql(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<TablePayment> tablePayments { get; set; }
        public DbSet<CustomersPayment> customersPayments { get; set; }
        public DbSet<BusinessClient> businessClients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BusinessClient>().Property(x => x.NIP).IsRequired();
            modelBuilder.Entity<BusinessClient>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<BusinessClient>().Property(x => x.PhoneNumber).IsRequired();
            modelBuilder.Entity<BusinessClient>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<BusinessClient>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<BusinessClient>().HasIndex(x => x.NIP).IsUnique();

            modelBuilder.Entity<Customer>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.PhoneNumber).IsRequired();
            modelBuilder.Entity<Customer>().HasIndex(x => x.Email).IsUnique();

            modelBuilder.Entity<Employee>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<Employee>().Property(x => x.PhoneNumber).IsRequired();
            modelBuilder.Entity<Employee>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<Employee>().HasIndex(x => x.Email).IsUnique();

        }
    }
}
