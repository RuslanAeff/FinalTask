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
        private List<Sale> sales;
        private List<SaleItem> sale_İtems;
        private List<Category> categories;

        public MarketService()
        {
            products = new List<Product>();
            sales = new List<Sale>();
            sale_İtems = new List<SaleItem>();
            categories = new List<Category>();
        }

        public int AddProduct(string name, int price, Category catagory, int number) 
        {        
            if (string.IsNullOrEmpty(name))   throw new ArgumentNullException("Name is null!"); 
            if (price <= 0)  throw new Exception("Price is negative"); 
            if (number < 0) { throw new Exception("Number is negative"); }
            if (catagory == null) throw new Exception("There is no Category!");
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
            if (id < 0) throw new Exception("ID cannot be negative!");
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

        public void AddSale(int id ,int quantity,DateTime time)
        {
            List<SaleItem> tempSale = new List<SaleItem>();

            var product = products.FirstOrDefault(x => x.Id == id);
            if (quantity < 0) throw new Exception("Quantity must be grater than 0!");
            else if (product.Number < quantity) throw new Exception("Not enough product in stock!");
            else if (product == null) throw new Exception("Product is not found");
            else
            {
                var sum = product.Price * quantity;
                var saleItem = new SaleItem(product, quantity);
                tempSale.Add(saleItem);
                var sale = new Sale(sum, time);

                foreach (var item in tempSale)
                {
                    sale.AddSaleItem(item);
                }
                sales.Add(sale);
                Console.WriteLine("Sale added successfuly!");

                int option;
                do
                {
                    Console.WriteLine(" Do u want to add another sale item?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");

                    while(!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid option!");
                        Console.WriteLine("Enter option again:");
                    }
                    switch(option)
                    {
                        case 1:
                            Console.WriteLine("Add product ID for sale: ");
                            int saleId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter number:");
                            int secondnumber = int.Parse(Console.ReadLine());

                            var newProduct = products.Find(x => x.Id == saleId);
                            var secondSum = product.Price * secondnumber;
                            newProduct.Number -= secondnumber;

                            var newSaleItem = new SaleItem(newProduct, secondnumber);
                            sale_İtems.Add(newSaleItem);
                            sale = new Sale(secondSum, DateTime.Today);
                            foreach (var item in sale_İtems)
                            {
                                sale.AddSaleItem(item);
                            }
                            
                            break;
                        case 2:
                            Console.WriteLine("Sale added successfuly!");
                            Console.WriteLine("                       ");
                            return;
                        default:
                            Console.WriteLine("No such option!");
                            break;
                            
                    }

                } while (option != 2);
                
            }
        }
        public void DeleteSale(int id)
        {
            if (id < 0) throw new Exception("ID cannot be negative!");
            int getsaleid = sales.FindIndex(x => x.Id == id);
            if (getsaleid == -1) throw new Exception("Sale not found!");
            sales.RemoveAt(getsaleid);
        }
        public List<Sale> ShowSalesForDateRange(DateTime mintime, DateTime maxtime)
        {  
            if (mintime > maxtime) throw new Exception("Minimum time cannot be greater than maximum time!");
            List<Sale> result = sales.Where(x=>x.Time >= mintime && x.Time <= maxtime).ToList();
            if (result == null) throw new Exception("Sale is not found!");
            return result;
        }
        public List<Sale> ShowSalesForGivenAmount(double minamount,  double maxamount)
        {
            if (minamount > maxamount) throw new Exception("Minamonut cannot be greater than maxamount!");
            List<Sale> result = sales.Where(x=> x.Amount >= minamount && x.Amount <= maxamount).ToList();
            if (result == null) throw new Exception("Sale is not found!");
            return result;
        }
        public List<Product> GetProducts()
        {
            return products; 
        }
        public List<Sale> GetSale()
        {
            return sales;
        }
        public List<SaleItem> GetSaleItems()
        {
            return sale_İtems;
        }
    
    }
}
