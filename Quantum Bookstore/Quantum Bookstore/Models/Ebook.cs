using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Bookstore.Models
{
    enum FileType
    {
        Txt,
        Pdf,
        Docx,
        Doc,
        HTML
    }
    class Ebook: Book
    {
        public FileType Type { get; set; }

        public Ebook(string isbn, string Title, string Author, decimal Price, DateTime PubDate, FileType Type) :base(isbn, Title, Author, Price, PubDate)
        {
            this.Type = Type;
            bookDelivery = new EmailService();
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
