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
            
            
            
            
            
            } while (option == 0);
        }
    }
}