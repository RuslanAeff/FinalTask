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

        public int AddProduct(string name, int price, Category catagory, int number) 
        {
            if (string.IsNullOrEmpty(name))   throw new ArgumentNullException("Name is null!"); 
            if (price < 0)  throw new Exception("Price is negative"); 
            if (number < 0) { throw new Exception("Number is negative"); }
            if (catagory != catagory)  throw new Exception("There is no Category!"); 
            var product = new Product (name, price, catagory, number);
                products.Add(product);
                return product.Id;
        }
        
        public void EditProduct (int id,string name, int price, Category catagory, int number)
        {
            if (!string.IsNullOrEmpty(name))  throw new Exception("Name is null!"); 
            if (price < 0)  throw new Exception("Price is negative"); 
            if (number < 0)  throw new Exception("Number is negative"); 
            if (catagory!=catagory)  throw new Exception("There is no category!"); 
            if (id < 0) throw new Exception("ID is negative!");
            var existing = products.FirstOrDefault(x => x.Id ==id);
            if (existing == null) throw new Exception("Product not found!");
            existing.Name = name;
            existing.Price = price;
            existing.Catagory = catagory;
            existing.Number = number;
        }
        public void DeleteProduct (int id)
        {
            if (id < 0) throw new Exception("There is no Product!");
            int getproduct = products.FindIndex(x => x.Id == id);
            if (getproduct == -1) throw new Exception("Products not found!");
            products.RemoveAt(getproduct);
        }
        public List<Product> GetProducts()
        {
            return products; 
        }
    }
}
