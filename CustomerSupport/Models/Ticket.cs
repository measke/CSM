using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerSupport.Models
{
    public class Ticket
    {
        
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? SolvedDate { get; private set; }
        public bool OverDue => 
            DueDate < DateTime.Now.AddHours(1);
        public bool Solved =>
            SolvedDate.HasValue; 
        public void Solve()
        {
            SolvedDate = DateTime.Now;
        }
    }


}
