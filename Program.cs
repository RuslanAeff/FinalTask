using MarektDemo.Services.Concrete;
using System;
using System.Data.SqlTypes;

namespace MarketDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Mehsullar uzerinde emeliyyat aparmaq");
                Console.WriteLine("2. Satishlar uzerinde emeliyyat aparmaq");
                Console.WriteLine("3. Sistemden chixish");
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
                     // MenuService.MenuAddNewProduct();
                    case 2:
                     // MenuService.MenuEditProduct();
                    case 3:
                     // MenuService.MenuDeleteProduct();
                     case 4:
                     // MenuService.MenuShowAllProducts():
                     case 5:
                     // MenuService.MenuShowProductsForCatagory();
                     case 6:
                     // MenuService.MenuShowProductsForPriceRange();
                     case 7:
                     // MenuService.MenuSearchProductbyName();
                    default:
                        break;
                }



            } while (option == 0);
        }
    }
}