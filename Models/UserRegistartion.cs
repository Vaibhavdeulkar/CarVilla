using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Authenecation_and_authoraization.Models
{
    [Table("UserRegistation")]
    public class UserRegistartion
    {
        [ScaffoldColumn (false)]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required( ErrorMessage = "please eneter the name")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required (ErrorMessage = "Please enetr email")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required (ErrorMessage ="Please enetr email")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+])[A-Za-z\d!@#$%^&*()_+]{6,}$")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Required (ErrorMessage = "confirm the password")]
        [Compare ("Password" ,ErrorMessage = "password did not matchec")]
        public string ConFirmPassword { get; set; }


    }
}