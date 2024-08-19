using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Data.Entities.Premition;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDelete);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }

        #region role

        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion


        #region Premition


        public DbSet<Premitions> premitions { get; set; }
        public DbSet<RolePremition> rolePremitions { get; set; }
        #endregion


    }
}
