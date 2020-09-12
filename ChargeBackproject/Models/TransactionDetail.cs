using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChargeBackproject.Models
{
    public class TransactionDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("Debit")]
        public int Debit { get; set; }

        [DisplayName("Credit")]
        public int Credit { get; set; }

        [DisplayName("Payment Date (dd/mm/yyyy)")]
        public string PaymentDate { get; set; }

        [DisplayName("Due Date (dd/mm/yyyy)")]
        public string DueDate { get; set; }

        [DisplayName("Late Fee")]
        public int LateFee { get; set; }

    }
}