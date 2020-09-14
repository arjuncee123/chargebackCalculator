using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Web;

namespace ChargeBackproject.Models
{
    public class ComplaintDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }

        [Required]
        [DisplayName("Email ID")]
        public string EmailId { get; set; }

        [Required]
        [DisplayName("Account Number")]
        public int BankAccountNumber { get; set; }

        [Required]
        [DisplayName("Bank Branch name")]
        public string BranchName { get; set; }

        [Required]
        [DisplayName("Reason")]
        public string Reason { get; set; }

        [Required]
        [DisplayName("ChargeBack Amount")]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of transaction in (dd/mm/yyyy)")]
        public DateTime? DateOfTransaction { get; set; }

    }
}