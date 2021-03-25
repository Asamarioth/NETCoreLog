using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETCoreLog.Models.Identity;
namespace NETCoreLog.Models
{
    public class Database :IdentityDbContext<User>
    {
        public Database(DbContextOptions<Database> options) : base(options) { }
    }
}
