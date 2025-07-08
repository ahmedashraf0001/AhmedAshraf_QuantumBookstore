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
            if (Stock == 0 || qty > Stock) 
            {
                throw new InvalidOperationException("Not enough stock.");
            }
            Stock -= qty;
            bookDelivery.Deliver(this, email, addr);
            return price * qty;
        }
    }
}
