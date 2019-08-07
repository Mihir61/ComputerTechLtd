using ComputerTechLtd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerTechLtd.Controllers
{
    public class OrderController : Controller
    {
        private readonly CustomerContext context = new CustomerContext();
        // GET: Customer
        public ActionResult Index()
        {
            var order = context.OrderEntity.ToList();
            return View(order);
        }

        public ActionResult Create()
        {
            return View(new Order());
        }
        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                context.OrderEntity.Add(order);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(order);
        }
    }
}