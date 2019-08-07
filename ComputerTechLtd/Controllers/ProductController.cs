using ComputerTechLtd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerTechLtd.Controllers
{
    public class ProductController : Controller
    {
        private readonly CustomerContext context = new CustomerContext();
        // GET: Customer
        public ActionResult Index()
        {
            var product = context.productEntity.ToList();
            return View(product);
        }

        public ActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                context.productEntity.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(product);
        }
    }
}