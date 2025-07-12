using Quantum_Bookstore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Bookstore.Models
{
    public abstract class Book
    {
        public string isbn { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public decimal price { get; set; }
        public DateTime pubdate { get; set; }
        public IBookService bookDelivery { get; set; }

        public Book(string isbn, string title, string author, decimal price, DateTime pubdate) 
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("provide the ISBN.");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("provide a title for the book.");

            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("The book needs an author.");

            if (price < 0)
                throw new ArgumentException("Price can't be negative");

            if (pubdate > DateTime.Now)
                throw new ArgumentException("This book hasn't been published yet, Check the date.");

            this.isbn = isbn;
            this.title = title; 
            this.price = price;
            this.author = author;
            this.pubdate = pubdate;
        }
        public abstract decimal Buy(int qty, string email, string addr);
    }
    
}
