using System;
using System.Collections.Generic;
using System.Linq;
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
        
        
       
    }
}
