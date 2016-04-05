using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.Models;

namespace Database
{
    public class DemoContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
    }
}
