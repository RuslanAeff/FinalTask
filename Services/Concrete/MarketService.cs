﻿using MarektDemo.DATA.Enum;
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
        private List<Sale> sales;
        private List<Sale_item> sale_İtems;
        private List<Category> categories;

        public MarketService()
        {
            products = new List<Product>();
            sales = new List<Sale>();
            sale_İtems = new List<Sale_item>();
            categories = new List<Category>();
        }

        public int AddProduct(string name, int price, Category catagory, int number) 
        {
            
            if (string.IsNullOrEmpty(name))   throw new ArgumentNullException("Name is null!"); 
            if (price <= 0)  throw new Exception("Price is negative"); 
            if (number < 0) { throw new Exception("Number is negative"); }
            if (catagory ==null) throw new Exception("There is no Category!");
            var product = new Product (name, price, catagory, number);
                products.Add(product);
                return product.Id;
        }
        
        public void EditProduct (int id,string name, int price, Category catagory, int number)
        {
            if (!string.IsNullOrEmpty(name))  throw new Exception("Name is null!"); 
            if (price <= 0)  throw new Exception("Price is negative"); 
            if (number < 0)  throw new Exception("Number is negative"); 
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
        public List<Product> ShowProductsForPriceRange(int minamount, int maxamount) 
        {
            if (minamount <= 0) throw new Exception("minamount cannot be less than 0 or equals 0");
            if (maxamount <= 0) throw new Exception("minamount cannot be less than 0 or equals 0");
            if (minamount > maxamount) throw new Exception("minamount cannot be greater than maxamount!");
            return products.Where(x => x.Price >=minamount && x.Price <=maxamount).ToList();

        }
        public List<Product> GetProducts()
        {
            return products; 
        }
        public List<Sale> GetSale()
        {
            return sales;
        }
        public List<Sale_item> GetSaleItems()
        {
            return sale_İtems;
        }
    
    }
}
