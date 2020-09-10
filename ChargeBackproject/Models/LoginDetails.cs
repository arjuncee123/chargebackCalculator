using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChargeBackproject.Models
{
    public class LoginDetails
    {
        public string RoleOfUser { get; set; }
        [Key]
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}