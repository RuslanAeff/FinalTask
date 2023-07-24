using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Models
{
    internal class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string catagory { get; set; }
        public int Number { get; set; }


    }
}
