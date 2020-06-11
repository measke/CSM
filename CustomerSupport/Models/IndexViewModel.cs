using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSupport.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Ticket> Solved { get; set; }
        public IEnumerable<Ticket> Unsolved { get; set; }
    }
}
