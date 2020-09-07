using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChargeBackproject.Models
{
    public class UserRoles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("UserName")]
        public int USerId { get; set; }

        public LoginDetails UserName { get; set; }

        [StringLength(10)]
        public string Role { get; set; }


    }
}