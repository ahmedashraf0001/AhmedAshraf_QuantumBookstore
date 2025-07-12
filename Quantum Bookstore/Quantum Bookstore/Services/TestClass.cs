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
            Console.WriteLine("Books added.\n");

            // Buying test
            try
            {
                var paid = inv.BuyBook("ahmed", 2, "mario@email.com", "Cairo, Egypt");
                Console.WriteLine($"ahmed purchase: ${paid}\n");

                Console.WriteLine($"ziad purchase: ${inv.BuyBook("ziad", 1, "mario@email.com", "Cairo, Egypt")}\n");

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

            //Outdated books
            var oldOnes = inv.removeOutdated(3);
            if (oldOnes.Count > 0)
            {
                Console.WriteLine($"Outdated books removed: {oldOnes.Count}");
                foreach (var b in oldOnes)
                {
                    Console.WriteLine($"{b.title} - {b.author}");
                }
            }

            Console.WriteLine("\n============== errors ==============\n");

            //Book not found
            try
            {
                inv.BuyBook("fake", 1, "test@email.com", "Cairo, Egypt");
                Console.WriteLine("Buy went through?? Shouldn't happen");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught expected error (book not found): " + ex.Message + "\n");
            }

            //invalid isbn
            try
            {
                var invalid = new Paper_book("", "invalid book", "Someone", 10.99m, DateTime.Now, 5);
                inv.AddToInventory(invalid);
                inv.BuyBook("", 1, "test@email.com", "Cairo, Egypt");
                Console.WriteLine("Invalid ISBN buy went through?? Shouldn't happen");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught expected ISBN error: " + ex.Message + "\n");
            }

            var fresh = new Paper_book("ahmed", "intro to C#", "Ahmed ashraf", 29.99m, new DateTime(2020, 1, 1), 10);
            inv.AddToInventory(fresh);

            //qty > stock
            try
            {
                inv.BuyBook("ahmed", 100, "mario@email.com", "Cairo, Egypt");
                Console.WriteLine("Over-stock buy went through?? Shouldn't happen");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught expected stock error: " + ex.Message + "\n");
            }

            //invalid qty = 0
            try
            {
                inv.BuyBook("ahmed", 0, "mario@email.com", "Cairo, Egypt");
                Console.WriteLine("Zero quantity buy went through?? Shouldn't happen");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught expected quantity error (zero): " + ex.Message + "\n");
            }

            //invalid qty = -1
            try
            {
                inv.BuyBook("ahmed", -1, "mario@email.com", "Cairo, Egypt");
                Console.WriteLine("Negative quantity buy went through?? Shouldn't happen");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught expected quantity error (negative): " + ex.Message + "\n");
            }

            Console.WriteLine("\nDone with tests.");
        }
    }
}
