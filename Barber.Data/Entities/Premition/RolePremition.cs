using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Data.Entities.Premition
{
    public class RolePremition
    {
        [Key]
        public int RP_id { get; set; }

        public int RoleId { get; set; }

        public int PremitionId { get; set; }
    }
}
