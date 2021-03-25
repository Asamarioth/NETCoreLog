using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace NETCoreLog.Models.Identity
{
    public class LoginViewModel
    {
        [Required][EmailAddress][Display(Name ="Email")]
        public String Email{ get; set; }
        [Required][DataType(DataType.Password)][MinLength(8)][Display(Name ="Hasło")]
        public String Password{ get; set; }

    }
}
