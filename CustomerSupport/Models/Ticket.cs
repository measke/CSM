using System;

namespace CustomerSupport.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime EntryDate { get; set; }
        public bool OverDue { get; set; }
        public bool Solved { get; set; }
    }

}
