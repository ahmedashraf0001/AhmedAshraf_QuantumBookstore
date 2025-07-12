using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Bookstore.Models
{
    class Paper_book: Book
    {
        public int Stock { get; set; }

        public Paper_book(string ISBN, string Title, string Author, decimal Price, DateTime PublishDate, int stock):base(ISBN, Title, Author, Price, PublishDate)
        {
            Stock = stock;
            bookDelivery = new ShippingService();
        }

        public override decimal Buy(int qty, string email, string addr)
        {
            if (qty <= 0)
                throw new ArgumentException("enter a quantity greater than zero.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("provide email to deliver your book.");

            if (string.IsNullOrWhiteSpace(addr))
                throw new ArgumentException("provide a delivery address.");

            if (Stock < qty)
                throw new InvalidOperationException("not enough stock available.");

            Stock -= qty;
            bookDelivery.Deliver(this, email, addr);
            return price * qty;
        }
    }
}
