using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.Models
{
    public class TrueDB:DbContext
    {
        public TrueDB(DbContextOptions<TrueDB> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
    }
}
