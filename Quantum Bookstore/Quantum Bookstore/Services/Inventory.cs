using Quantum_Bookstore.Interfaces;
using Quantum_Bookstore.Models;
using System;
using System.Collections.Generic;

namespace Quantum_Bookstore.Services
{
    public class Inventory : IInventory
    {
        private readonly Dictionary<string, Book> _books = new();

        public void AddToInventory(Book b)
        {
            _books[b.isbn] = b;
        }

        public decimal BuyBook(string isbn, int quantity, string email, string address)
        {
            if (!_books.TryGetValue(isbn, out var b))
                throw new KeyNotFoundException("Book not found in inventory.");

            return b.Buy(quantity, email, address);
        }

        public Book deleteFromInventory(string isbn)
        {
            if (!_books.TryGetValue(isbn, out var b))
                return null;

            _books.Remove(isbn);
            return b;
        }

        public List<Book> removeOutdated(int maxAge)
        {
            var outdated = new List<Book>();

            foreach (var kv in _books)
            {
                var age = DateTime.Now.Year - kv.Value.pubdate.Year;
                if (age > maxAge)
                {
                    outdated.Add(kv.Value);
                }
            }

            foreach (var b in outdated)
            {
                _books.Remove(b.isbn);
            }

            return outdated;
        }

    }
}
