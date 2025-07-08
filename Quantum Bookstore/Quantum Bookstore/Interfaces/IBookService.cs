using Quantum_Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Bookstore.Interfaces
{
    public interface IBookService
    {
        void Deliver(Book book, string email, string addr);
    }
}
