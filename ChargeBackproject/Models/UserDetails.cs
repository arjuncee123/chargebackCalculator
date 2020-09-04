using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ChargeBackproject.Models
{
    public class UserDetails
    {
        [Key]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }


        [Required(ErrorMessage = "Please Enter gender")]
        public string Gender { get; set; }


        [DisplayName("Phone Number")]
        public string ContactNumber { get; set; }


        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter ZipCode")]
        public int ZipCode { get; set; }

    }
}