using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Authenecation_and_authoraization.Models
{
    public class db : DbContext
    {
        public DbSet<UserRegistartion> RegistrationDetails  {get; set;}
    }
}