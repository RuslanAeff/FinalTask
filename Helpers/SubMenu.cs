﻿using MarektDemo.Services.Abstract;
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
                    // MenuService.MenuEditProduct();
                    case 3:
                    // MenuService.MenuDeleteProduct();
                    case 4:
                    // MenuService.MenuShowAllProducts():
                    case 5:
                    // MenuService.MenuShowProductsForCategory();
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