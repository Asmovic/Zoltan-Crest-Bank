using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ZoltanCrestBank.Models;
using ZoltanCrestBank.Services;

namespace ZoltanCrestBank.Controllers
{
    public class MainController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: /Main/
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            // db.Dispose();
            var customers = db.customers.Include(c => c.User);

            //  return Json(customers.ToList(), JsonRequestBehavior.AllowGet);
            return View(customers.ToList());
        }



        //public ActionResult Index(int? id)
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customers customers = db.customers.Find(id);
        //    if (customers == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customers);
        //}

        // GET: /Main/Details/5
        public ActionResult Details(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: /Main/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Pin");
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var userId = User.Identity.GetUserId();

            try
            {
                foreach (string _formData in collection)
                {
                    ViewData[_formData] = collection[_formData];
                }

                var service = new CustomerService(HttpContext.GetOwinContext().Get<ApplicationDbContext>());

                service.CreateCustomer(ViewData["firstName"].ToString(), ViewData["lastName"].ToString(), userId, decimal.Parse(ViewData["balance"].ToString()));


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: /Main/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="id,AccountNumber,firstName,lastName,balance,ApplicationUserId")] Customers customers)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.customers.Add(customers);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Pin", customers.ApplicationUserId);
        //    return View(customers);
        //}

        // GET: /Main/Edit/5
        public ActionResult Edit(int? id)
        {
            //using(ApplicationDbContext db = new ApplicationDbContext())
            //{
            //    return View(db.customers.Where(x => x.id == id).FirstOrDefault());
            //}
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Pin", customers.ApplicationUserId);
            return View(customers);
        }

        // POST: /Main/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Customers customer)
        {
            try
            {
                using(ApplicationDbContext dm = new ApplicationDbContext())
                {
                    dm.Entry(customer).State = EntityState.Modified;
                    dm.SaveChanges();
                }
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
        //public ActionResult Edit([Bind(Include="firstName,lastName,balance")] Customers customers)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(customers).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Pin", customers.ApplicationUserId);
        //    return View(customers);
        //}

        // GET: /Main/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: /Main/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.customers.Find(id);
            db.customers.Remove(customers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
