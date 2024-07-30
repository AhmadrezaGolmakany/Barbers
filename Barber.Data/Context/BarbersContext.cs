using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Barber.Data.Context
{
    public class BarbersContext : DbContext
    {
        public BarbersContext(DbContextOptions<BarbersContext> options) :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
