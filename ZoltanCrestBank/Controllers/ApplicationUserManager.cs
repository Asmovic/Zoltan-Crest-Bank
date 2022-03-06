using ZoltanCrestBank.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Owin;

namespace ZoltanCrestBank.Controllers
{
    public class ApplicationUserManager
    {

        private Microsoft.AspNet.Identity.EntityFramework.UserStore<Models.ApplicationUser> userStore;

        public ApplicationUserManager(Microsoft.AspNet.Identity.EntityFramework.UserStore<Models.ApplicationUser> userStore)
        {
            // TODO: Complete member initialization
            this.userStore = userStore;
        }


        //       private ApplicationUserManager _userManager;

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}
        internal ApplicationUser FindById(string userId)
        {
            using (var db = new ApplicationDbContext())
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            }

            //using (var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext())))
            //{

            //}

            throw new NotImplementedException();
        }
    }
}