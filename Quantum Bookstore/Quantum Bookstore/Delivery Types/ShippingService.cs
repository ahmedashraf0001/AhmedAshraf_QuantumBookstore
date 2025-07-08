using Quantum_Bookstore.Interfaces;
using Quantum_Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Bookstore
{
    class ShippingService : IBookService
    {
        public void Deliver(Book book, string email, string addr)
        {
            Console.WriteLine($"Shipping '{book.title}' to '{addr}'");
        }
    }
}
