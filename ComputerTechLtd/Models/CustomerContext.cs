using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ComputerTechLtd.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("DbConnection")
        {

        }
        public DbSet<Customer> customerEntity { get; set; }
        public DbSet<Product> productEntity { get; set; }
        public DbSet<Order> OrderEntity { get; set; }
        public DbSet<OrderItem> OrderItemEntity { get; set; }
    }
}