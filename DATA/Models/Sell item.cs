using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Models
{
    public class SaleItem 
    {
        private static int counter = 0;
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Number { get; set; }

        public SaleItem (Product product, int number)
        {
            if (product.Number < number || number < 0) 
                throw new ArgumentException($"Cannot make a sale item of {number} {product.Name} which " +
                    $"{product.Number} of it exist in the storage!");
            Product = product;
            Number = number;
            counter++;
        }

    }
}
