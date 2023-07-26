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
            try
            {    var products = marketservice.GetProducts();
                Console.WriteLine("Enter product's category:");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);

                if (category != category) throw new Exception("There is no product!");

                var table = new ConsoleTable("Category");
                foreach ( var product in products )
                {
                    table.AddRow(product.Catagory);
                }
                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
            

        }
    }
}
