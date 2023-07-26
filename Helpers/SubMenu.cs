using MarektDemo.Services.Abstract;
using MarektDemo.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Helpers
{
    public class SubMenu 
    {
        public static void SubMenuHelp()
        {


            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Edit product");
                Console.WriteLine("3. Delete product");
                Console.WriteLine("4. Show all products");
                Console.WriteLine("5. Show products for category");
                Console.WriteLine("6. Show product for pricerange");
                Console.WriteLine("7. Search product by name");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please enter option:");
                Console.WriteLine("------------------------");




                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option!");
                    Console.WriteLine("Enter an option please:");
                    Console.WriteLine("----------------");
                }

                switch (option)
                {
                    case 1:
                       MenuService.MenuAddNewProduct();
                       break;
                    case 2:
                       MenuService.MenuEditProduct();
                       break;
                    case 3:
                       MenuService.MenuDeleteProduct();
                       break;
                    case 4:
                       MenuService.MenuShowAllProducts();
                       break;
                    case 5:
                       MenuService.MenuShowProductsForCategory();
                        break;
                    case 6:
                       MenuService.MenuShowProductsForPriceRange();
                        break;
                    case 7:
                       MenuService.MenuSearchProductbyName();
                        break;
                    case 0:
                       Console.Clear();
                        break;
                    default:
                        Console.WriteLine("There is no such option!");
                        break;
                }



            } while (option != 0);

        }
    }
}
