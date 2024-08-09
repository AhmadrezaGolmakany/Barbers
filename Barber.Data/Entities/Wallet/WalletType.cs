using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Data.Entities.Wallet
{
    public class WalletType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeId { get; set; }

        public string TypeName { get; set; }

        



        public virtual List<Wallet> Wallets { get; set; }
        
    }
}
