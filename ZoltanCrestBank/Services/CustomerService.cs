using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoltanCrestBank.Models;

namespace ZoltanCrestBank.Services
{
    public class CustomerService
    {
        private ApplicationDbContext db;

        public CustomerService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public void CreateCustomer(string firstName, string lastName, string userId, decimal initialBalance)
        {

            var accountNumber = (db.customers.Count()).ToString().PadLeft(10, '0');
            var customer = new Customers { firstName = firstName, lastName = lastName, AccountNumber = accountNumber, balance = initialBalance, ApplicationUserId = userId };
            db.customers.Add(customer);

            db.SaveChanges();
        }

        public void CreateCheckingBalance(string firstName, string lastName, string userId, decimal initialBalance)
        {

            var accountNumber = (1234567 + db.customers.Count()).ToString().PadLeft(10, '0');
            var customer = new Customers { firstName = firstName, lastName = lastName, AccountNumber = accountNumber, balance = initialBalance, ApplicationUserId = userId };
            db.customers.Add(customer);

            db.SaveChanges();
        }

    }
}