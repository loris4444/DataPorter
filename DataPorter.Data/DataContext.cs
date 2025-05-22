using Microsoft.EntityFrameworkCore;
using DataPorter.Entity;

namespace DataPorter.Data 
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Customers)
                .WithOne(co => co.Company)
                .HasForeignKey(co => co.CompanyId);
            modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = "Sdd",
                Name = "OpenAI",
                Location = "San Francisco",
                FoundationDate = new DateTime(2015, 12, 11),
                Employees = 375,
                Revenue = 10000000.0,
                Customers = new List<Customer>()
            },
            new Company
            {
                Id = "Xkg",
                Name = "Microsoft",
                Location = "Redmond",
                FoundationDate = new DateTime(1975, 4, 4),
                Employees = 220000,
                Revenue = 198000000000.0,
                Customers = new List<Customer>()
            }
        );

        }
    }
}
