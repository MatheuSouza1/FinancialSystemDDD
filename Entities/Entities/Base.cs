using Entities.Entities.Not;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Base : Notify
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
