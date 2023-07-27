using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Models
{
    public class Sale: BaseEntity
    {
        public double Amount { get; set; }
        public string Sellitem { get; set; }
        public DateTime Time { get; set; }


    }
}
