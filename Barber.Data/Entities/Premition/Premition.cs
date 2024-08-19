using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Data.Entities.Premition
{
    public class Premitions
    {
        [Key]
        public int PremitionId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string title { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public List<Premitions> premitions { get; set; }

    }
}
