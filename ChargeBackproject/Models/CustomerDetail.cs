using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChargeBackproject.Models
{
    public class CustomerDetail
    {
        [Required(ErrorMessage = "Please Enter First Name")]
        [StringLength(40, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth in (dd/mm/yyyy)")]
        public DateTime? DateOfBirth { get; set; }


        [Required(ErrorMessage = "Please Enter gender")]
        public string Gender { get; set; }


        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Please Enter contact number")]
        public string ContactNumber { get; set; }


        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter ZipCode")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Please Enter UserId")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Key]
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("Account Number")]
        public int BankAccountNumber { get; set; }

        [DisplayName("Bank Address")]
        public string BankAddress { get; set; }

        [DisplayName("Bank Branch name")]
        public string BranchName { get; set; }

        [DisplayName("Balance Available")]
        public int AvailableBalance { get; set; }
    }
}