using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComputerTechLtd.Models
{
    [NotMapped]
    public class OrderModel:Order
    {
        public List<OrderItem> OrderItemList { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<Product> ProductList { get; set; }

        private CustomerContext _context;

        public OrderModel()
        {
            _context = new CustomerContext();
            CustomerList = _context.customerEntity.ToList();
            ProductList = _context.productEntity.ToList();
            OrderItemList = _context.OrderItemEntity.ToList();

        }
    }
}