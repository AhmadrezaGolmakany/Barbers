using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Data.Entities.User;
using Barber.Data.Entities.Wallet;
using Microsoft.EntityFrameworkCore;

namespace Barber.Data.Context
{
    public class BarbersContext : DbContext
    {
        public BarbersContext(DbContextOptions<BarbersContext> options) :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
    }
}
