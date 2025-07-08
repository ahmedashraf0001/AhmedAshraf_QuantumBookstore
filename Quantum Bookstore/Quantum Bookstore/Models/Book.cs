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
            this.isbn = isbn;
            this.title = title; 
            this.price = price;
            this.author = author;
            this.pubdate = pubdate;
        }
        public abstract decimal Buy(int qty, string email, string addr);
    }
    
}
