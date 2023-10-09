using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Expenditure : Base
    {
        public decimal value { get; set; }
        public int month { get; set; }
        public int year { get; set; }

        public DateTime RegisterDate { get; set; }
        public DateTime AltDate { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public bool IsOverdue { get; set; }

        [ForeignKey("Category")]
        [Column(Order = 1)]

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
