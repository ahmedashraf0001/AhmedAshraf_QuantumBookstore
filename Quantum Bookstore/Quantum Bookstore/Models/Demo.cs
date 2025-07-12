using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Bookstore.Models
{
    class Demo_book: Book
    {
        public Demo_book(string ISBN, string Title, string Author, DateTime PublishDate) : base(ISBN, Title, Author, 0, PublishDate)
        {
            bookDelivery = new NoDelivery();
        }
        public override decimal Buy(int qty, string email, string addr)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("provide email to deliver your book.");

            if (string.IsNullOrWhiteSpace(addr))
                throw new ArgumentException("provide a delivery address.");
            bookDelivery.Deliver(this, email, addr);
            return price * qty;
        }
    }
}
