using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace joseph_website.Models
{
    public class User
    {
        [Required(ErrorMessage = "Nee, geen goede voornaam.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nee, geen goede achternaam.")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Nee, geen goede email.")]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}