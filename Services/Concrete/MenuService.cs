using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace MarektDemo.Services.Concrete
{
    internal class MenuService
    {
        public static void MenuAddNewProduct ()
        {
            try 
            {
                var products = MarketService.GetProducts();

                if (products.count==0 )
                {
                    Console.WriteLine("There is no products!");
                    return;
                }
                var table = new ConsoleTable("Id", "Name", "Price", "catagory", "Number");
                foreach ( var product in products ) 
                {
                    table.AddRow(product.Id, product.name, product.price, product.catagory, product.number);
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
