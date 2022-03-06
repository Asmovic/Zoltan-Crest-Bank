namespace ZoltanCrestBank.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZoltanCrestBank.Models;
    using ZoltanCrestBank.Services;

    internal sealed class Configuration : DbMigrationsConfiguration<ZoltanCrestBank.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ZoltanCrestBank.Models.ApplicationDbContext";
        }

        protected override void Seed(ZoltanCrestBank.Models.ApplicationDbContext context)
        {

            var UserStore = new UserStore<ApplicationUser>(context);
            var UserManager = new UserManager<ApplicationUser>(UserStore);

            if(!context.Users.Any(t=> t.UserName == "admin@zoltancrestbank.com"))
            {
                var user = new ApplicationUser { UserName = "admin@zoltancrestbank.com", Email = "admin@zoltancrestbank.com" };
                UserManager.Create(user, "passW0rd!");
                var service = new CustomerService(context);
                service.CreateCustomer("admin", "user", user.Id, 2000);
                context.Roles.AddOrUpdate(a => a.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();
                UserManager.AddToRole(user.Id, "Admin");
                
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
