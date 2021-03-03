using System;
using System.Collections.Generic;
using System.Text;

namespace OOPConsole.Models
{
    public class Transaction
    {  
        public User User { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Category { get; set; }

        public decimal Amount { get; set; }

        public string Print 
        { 
            get
            {
                return $"{Category} - {Amount} RON on date: {TimeStamp.ToShortDateString()} by {User.Name}";
            }
        }
    }
}
