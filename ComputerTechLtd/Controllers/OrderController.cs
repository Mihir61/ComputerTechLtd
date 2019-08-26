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
            return View(new OrderModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderModel orderModel)
        {
            var dt = DateTime.Now;
            var count = context.OrderEntity.Count(s => s.LastUpdate.Year == dt.Year && s.LastUpdate.Month == dt.Month && s.LastUpdate.Day == dt.Day);
            var order = new Order()
            {
                CustomerId = orderModel.CustomerId,
                LastUpdate = orderModel.LastUpdate,
                Status = "Approve",
                OrderNo = dt.ToString("yyMMdd") + (count + 1).ToString("0000")
            };
            context.OrderEntity.Add(order);
            context.SaveChanges();

            foreach(var item in orderModel.OrderItemList)
            {
                item.OrderId = order.Id;
                item.LastUpdate = DateTime.Now;
                context.OrderItemEntity.Add(item);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = context.OrderEntity.SingleOrDefault(e => e.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = context.OrderEntity.SingleOrDefault(e => e.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            var orderModel = new OrderModel()
            {
                OrderNo = order.OrderNo,
                Customer= order.Customer
                

            };
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            orderModel.OrderItemList = context.OrderItemEntity.Where(s => s.OrderId == order.Id).ToList();
            return View(orderModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = context.OrderEntity.SingleOrDefault(e => e.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var order = context.OrderEntity.SingleOrDefault(x => x.Id == id);
            context.OrderEntity.Remove(order ?? throw new InvalidOperationException());
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}