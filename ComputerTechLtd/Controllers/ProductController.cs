using ComputerTechLtd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = context.productEntity.SingleOrDefault(e => e.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = context.productEntity.SingleOrDefault(e => e.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = context.productEntity.SingleOrDefault(e => e.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = context.productEntity.SingleOrDefault(x => x.Id == id);
            context.productEntity.Remove(product ?? throw new InvalidOperationException());
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetProductPriceById(int id)
        {
            var product = context.productEntity.Find(id);
            return Json(new {price = product.ProductPrice });
        }
    }
}