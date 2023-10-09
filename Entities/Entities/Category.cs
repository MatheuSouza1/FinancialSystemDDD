using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Category : Base
    {
        [ForeignKey("FinancialSystem")]
        [Column(Order = 1)]
        public int SystemId { get; set; }
        public virtual Financial FinancialSystem { get; set; }
    }
}
