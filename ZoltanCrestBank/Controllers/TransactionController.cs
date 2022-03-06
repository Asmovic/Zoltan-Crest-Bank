using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Microsoft.AspNet.Identity.Owin;
using ZoltanCrestBank.Models;
using Microsoft.AspNet.Identity;

namespace ZoltanCrestBank.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Transaction/
        public ActionResult Index()
        {


            return View();
        }
	}
}