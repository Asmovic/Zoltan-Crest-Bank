using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoltanCrestBank.Models
{

    public class Customers
    {
        public Customers()
        {
            this.Transactions = new List<Transaction>();
        }

        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(10), MinLength(6)]
        [Column(TypeName = "varchar")]
        [RegularExpression(@"\d{6,10}", ErrorMessage = "Account Number must be between 6 to 10 digit")]
        [Display(Name = "Account #")]
        public string AccountNumber { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.firstName, this.lastName);
            }
        }
        [DataType(DataType.Currency)]
        public decimal balance { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }


        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [Required]
        public int CheckingBalanceId { get; set; }
        public Customers CheckingBalance { get; set; }



    }

}