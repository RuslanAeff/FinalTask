using MarektDemo.DATA.Enum;
using MarektDemo.Models;
using MarektDemo.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Services.Concrete
{
    public class MarketService : IMarketable
    {
        private List<Product> products;
        private List<Sell> sells;
        private List<Sell_item> sell_İtems;

        public MarketService()
        {
            products = new List<Product>();
            sells = new List<Sell>();
            sell_İtems = new List<Sell_item>();
        }

        public int AddProduct( string name, int price, Category catagory, int number) 
        {
            if (string.IsNullOrEmpty(name)) {  throw new ArgumentNullException("Name is null!"); }
            if (price < 0) { throw new Exception("Price is negative"); }
            if (number < 0) { throw new Exception("Number is negative"); }
            if (catagory != catagory) { throw new Exception("There is no Catagory!"); }
            var product = new Product (name, price, catagory, number);
                products.Add(product);
                return product.Id;
        }
        

    }
}
