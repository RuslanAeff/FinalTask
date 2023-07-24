using MarektDemo.DATA.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Models
{
    
    internal class Product : BaseEntity
    {
        private static int count =0;

        public string Name { get; set; }
        public int Price { get; set; }
        public Catagory Catagory { get; set; }
        public int Number { get; set; }

        public Product(string name, int price, Catagory catagory, int number)
        {
            Name = name;
            Price = price;
            Catagory = catagory;
            Number = number;

            Id = count;
            count++;

        }

    }
}
