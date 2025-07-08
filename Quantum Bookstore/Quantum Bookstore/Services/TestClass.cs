using Quantum_Bookstore.Models;
using System;
using System.Collections.Generic;

namespace Quantum_Bookstore.Services
{
    public class TestClass
    {
        public static void test()
        {
            Console.WriteLine("Running book inventory sanity checks...\n");

            var inv = new Inventory();

            var book1 = new Paper_book("ahmed", "intro to C#", "Ahmed ashraf", 29.99m, new DateTime(2020, 1, 1), 10);
            var book2 = new Ebook("ziad", "intro to C++", "Ziad hesham", 19.99m, new DateTime(2019, 5, 15), FileType.Pdf);
            var book3 = new Demo_book("mohamed", "intro to cooking", "Mohamed Ashraf", new DateTime(2023, 3, 10));

            inv.AddToInventory(book1);
            inv.AddToInventory(book2);
            inv.AddToInventory(book3);
            Console.WriteLine("Books added.");

            // Buying test
            try
            {
                var paid = inv.BuyBook("ahmed", 2, "mario@email.com", "Cairo, Egypt");
                Console.WriteLine($"ahmed purchase: ${paid}");

                Console.WriteLine($"ziad purchase: ${inv.BuyBook("ziad", 1, "mario@email.com", "Cairo, Egypt")}");

                var demoAmt = inv.BuyBook("mohamed", 1, "mario@email.com", "Cairo, Egypt");
                if (demoAmt == 0)
                {
                    Console.WriteLine($"Demo book is free (${demoAmt}) \n");
                }
                else
                {
                    Console.WriteLine($"Unexpected cost for demo book: {demoAmt}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Buying error occurred: " + e.Message);
            }

            // outdated books (>3 years)
            var oldOnes = inv.removeOutdated(3);
            if (oldOnes.Count > 0)
            {
                Console.WriteLine($"Outdated books removed: {oldOnes.Count}");
                foreach (var b in oldOnes)
                {
                    Console.WriteLine($"{b.title} - {b.author}");
                }
            }

            // Error scenario
            try
            {
                inv.BuyBook("fake", 1, "test@email.com", "Cairo, Egypt");
                Console.WriteLine("Buy went through?? Shouldn't happen");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nCaught expected error (good): " + ex.Message);
            }


            Console.WriteLine("Done with tests.");
        }
    }
}
