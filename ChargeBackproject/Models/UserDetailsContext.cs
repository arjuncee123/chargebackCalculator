using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChargeBackproject.Models
{
    public class UserDetailsContext : DbContext
    {
        public UserDetailsContext(): base("DefaultConnection")
        {

        }
        public DbSet<UserDetails> UserDetail { get; set; }

    }
}