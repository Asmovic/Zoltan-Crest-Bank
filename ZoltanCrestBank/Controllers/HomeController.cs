using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ZoltanCrestBank.Models;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace ZoltanCrestBank.Controllers
{
    public class HomeController : Controller
    {
        public static int glb;
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            var txt = "cribhrrtjkon";
            var userId = User.Identity.GetUserId();
             
            if(userId != null)
            {
                var customerId = db.customers.Where(c => c.ApplicationUserId == userId).First().id;
                glb = customerId;
                ViewBag.CustomerId = customerId;

                //  var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
                var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //  var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
      //          var user = manager.FindById(userId);


     //           ViewBag.Pin = user.Pin;

              
            }

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Having trouble? Contact Us!";

            return View();
        }

        //[HttpPost]
        //public ActionResult Contact(string message)
        //{
        //    ViewBag.Message = "Thanks, we got your message";

        //    return View();
        //}


        [HttpPost]
        public ActionResult Contact(string message)
        {

            ViewBag.Message = "Thanks, we got your Message!";
            return PartialView("_ContactPartial");
        }
    }
}