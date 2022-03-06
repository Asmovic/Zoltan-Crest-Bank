using ZoltanCrestBank.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.Owin;
using ZoltanCrestBank.Services;

namespace ZoltanCrestBank.Controllers
{
     
    public class CustomerController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Customer/Details
        [Authorize]
        
        public ActionResult Details()
        {
           // var userId = User.Identity.GetUserId();

            
           // Customers usid = new Customers();

           //usid = db.customers.Where(c => c.ApplicationUserId == userId).First();


           // return Json(usid, JsonRequestBehavior.AllowGet);

            var userId = User.Identity.GetUserId();
            db.Configuration.ProxyCreationEnabled = false;
            Customers usid = new Customers();
            usid = db.customers.Where(c => c.ApplicationUserId == userId).First();
            return Json(usid, JsonRequestBehavior.AllowGet);

           
        }

        public ActionResult test()
        {
            return Content("fcs");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            var userId = User.Identity.GetUserId();

            Customers usid = new Customers();


            usid = db.customers.Find(id);


            return View("Details", usid);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            return View(db.customers.ToList());
        }

        //
        // GET: /Customer/Create
        public ActionResult Create()
        {
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



       

        //
        // POST: /Customer/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
