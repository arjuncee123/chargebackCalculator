using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace ChargeBackproject.Models
{
    public class UserDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

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

        [NotMapped]
        [Required(ErrorMessage = "Please re-enter the password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }

        public string UserCategory { get; set; }
    }
}