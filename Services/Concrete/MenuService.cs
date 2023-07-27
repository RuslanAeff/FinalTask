using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using MarektDemo.DATA.Enum;

namespace MarektDemo.Services.Concrete
{
    public class MenuService
    {
        private static MarketService marketservice = new MarketService();

        public static void MenuAddNewProduct() 
        {
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter price");
                int price = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter catagory:");
                Console.WriteLine("               ");
                Console.WriteLine("1. Food  2. Electronics  3.Drinks");
                Category catagory = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);
               
                Console.WriteLine("Enter number:");
                int number = int.Parse(Console.ReadLine());

                int newId = marketservice.AddProduct(name, price, catagory, number);
                Console.WriteLine($"Product with ID {newId} was created!");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }            
        }    
       
        public static void MenuEditProduct() 
        {
            try
            {
                Console.WriteLine("Enter Id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter price:");
                int price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter category");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);
                Console.WriteLine("Enter number:");
                int number = int.Parse(Console.ReadLine());
                marketservice.EditProduct(id, name, price, category, number);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
         
        }
        public static void MenuDeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter product's ID:");
                int id = int.Parse(Console.ReadLine());

                marketservice.DeleteProduct(id);
                Console.WriteLine("The product deleted successfuly!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowAllProducts() 
        {
            try
            {
                var products = marketservice.GetProducts();

                if (products.Count ==0) 
                {
                    Console.WriteLine("There are no products!");
                }
                var table = new ConsoleTable("Id", "Name", "Price", "Category", "Number");
                foreach (var product in products)
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Catagory, product.Number);
                }
                table.Write();
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }           
        }

        public static void MenuShowProductsForCategory() 
        {
            Console.Clear();
            var array = Enum.GetValues(typeof(Category)).Cast<Category>().ToArray();
            try
            {
                var products = marketservice.GetProducts();
                Console.WriteLine($"1.Food 2.Electronics 3.Drinks");
                Console.WriteLine("                         ");
                Console.WriteLine("Enter product's category:");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);
                bool isEqual =  array.Any(c=> c.Equals(category));
                if (isEqual == false)
                {
                    throw new Exception("SomeThings Went Wrong!!!");
                }
                var table = new ConsoleTable("Id", "Name", "Price", "Category", "Number");
                var getcategory = products.FindAll(x => x.Catagory == category);
                foreach (var product in getcategory)
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Catagory, product.Number);
                }
                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowProductsForPriceRange()
        {
            try
            {
                Console.WriteLine("Enter minamount:");
                int minamount = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter maxamount:");
                int maxamount = int.Parse(Console.ReadLine());
                var existproduct = marketservice.ShowProductsForPriceRange(minamount, maxamount);
                if (existproduct.Count == 0)
                {
                    Console.WriteLine("Not Found!");
                }
                
                    var table = new ConsoleTable("Id", "Name", "Price", "Category", "Number");
                foreach (var product in existproduct)
                {
                    table.AddRow(product.Id, product.Name, product.Price,product.Catagory, product.Number);
                }
                table.Write();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }    
        }
        public static void MenuSearchProductbyName()
        {
            try
            {
                var products = marketservice.GetProducts();
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                if (products.Count == 0) throw new Exception("Not Found!");
                if (string.IsNullOrEmpty(name)) throw new Exception("Name cannot be null!");

                var table = new ConsoleTable("Id", "Name", "Price", "Category", "Number");
                
                var productna = products.Where(x => x.Name == name).ToArray();

                foreach (var productn in productna)
                {
                    table.AddRow(productn.Id, productn.Name, productn.Price, productn.Catagory, productn.Number);
                }
                table.Write();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }                         
        }

        public static void MenuAddNewSale()
        {
            try
            {
                Console.WriteLine("Enter product ID:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter sale's quantity");
                int quantity = int.Parse(Console.ReadLine());
                
                marketservice.AddSale(id, quantity, DateTime.Now);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
    
    
    }
}
