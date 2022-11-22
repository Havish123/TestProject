using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Solution.Data.Entity;

namespace TestProject.Solution.Data.DatabaseContext
{
    public class TestProjectContext:DbContext
    {
        public TestProjectContext(DbContextOptions<TestProjectContext> options):base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<OrderDetails> Orderdetails { get; set; }
    }
}
