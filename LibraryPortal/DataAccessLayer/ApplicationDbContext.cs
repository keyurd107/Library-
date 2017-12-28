using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class ApplicationDbContext:DbContext
    {
        public DbSet<UserDb> UserDb { get; set; }
        public DbSet<BookDb> BookDb { get; set; }
        public ApplicationDbContext():base("Login")
        {

        }
    }
}
