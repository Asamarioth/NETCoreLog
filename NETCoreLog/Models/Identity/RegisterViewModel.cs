using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace NETCoreLog.Models.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Display(Name = "Hasło")]
        public String Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Display(Name = "Potwierdź hasło")]
        [Compare(nameof(Password),ErrorMessage ="Hasła nie pasują do siebie")]
        public String ConfirmPassword { get; set; }
    }
}
