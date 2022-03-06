using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Microsoft.Owin.Security.Facebook;
using Newtonsoft.Json;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ZoltanCrestBank.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public string Pin { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
         public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

//        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
//{
//    ...
//}



         public DbSet<Customers> customers { get; set; }
         public DbSet<Transaction> Transactions { get; set; }

         //protected override void OnModelCreating(DbModelBuilder modelBuilder)
         //{
         //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
         //}
      //   public DbSet<Transaction> Transactions { get; set; }

    //     public System.Data.Entity.DbSet<ZoltanCrestBank.Models.ApplicationUser> IdentityUsers { get; set; }

      
    
    }
}