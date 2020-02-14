using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCheck_BE.Dtos
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "We need a username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "We need a valid email address")]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Required(ErrorMessage = "PIN is important to protect your information")]
        public int Pin { get; set; }

        [Required]
        public string CompanyName { get; set; }
    }
}
