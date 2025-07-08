using Quantum_Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Bookstore.Interfaces
{
    interface IInventory
    {
        public void AddToInventory(Book book);
        public Book deleteFromInventory(string isbn);
        public decimal BuyBook(string isbn, int qty, string email, string addr);
    }
}
