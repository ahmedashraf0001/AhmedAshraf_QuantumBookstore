using Quantum_Bookstore.Interfaces;
using Quantum_Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Bookstore
{
    class EmailService : IBookService
    {
        public void Deliver(Book book, string email, string add)
        {
            Console.WriteLine($"Emailing '{book.title}' to '{email}'");
        }
    }
}
