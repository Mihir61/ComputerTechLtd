using ComputerTechLtd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerTechLtd.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly CustomerContext context = new CustomerContext();
        // GET: Customer
        public ActionResult Index()
        {
            var orderitem = context.OrderItemEntity.ToList();
            return View(orderitem);
        }

        public ActionResult Create()
        {
            return View(new OrderItem());
        }
        [HttpPost]
        public ActionResult Create(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                context.OrderItemEntity.Add(orderitem);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(orderitem);
        }
    }
}