using ComputerTechLtd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace ComputerTechLtd.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerContext context = new CustomerContext();
        // GET: Customer
        public ActionResult Index()
        {
            var customer = context.customerEntity.ToList();
            return View(customer);
        }
       
        public ActionResult Create()
        {
            return View(new Customer());
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.customerEntity.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(customer);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = context.customerEntity.SingleOrDefault(e => e.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Entry(customer).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = context.customerEntity.SingleOrDefault(e => e.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = context.customerEntity.SingleOrDefault(e => e.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var customer = context.customerEntity.SingleOrDefault(x => x.Id == id);
            context.customerEntity.Remove(customer ?? throw new InvalidOperationException());
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}