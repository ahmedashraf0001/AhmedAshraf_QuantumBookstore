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
            if (b == null)
                throw new ArgumentException("Can't add a null book to inventory.");

            if (string.IsNullOrWhiteSpace(b.isbn))
                throw new ArgumentException("Book must have a valid ISBN.");

            _books[b.isbn] = b;
        }

        public decimal BuyBook(string isbn, int quantity, string email, string address)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("provide the ISBN.");

            if (!_books.TryGetValue(isbn, out var b))
                throw new KeyNotFoundException("the book isn't available in the inventory.");

            return b.Buy(quantity, email, address);
        }

        public Book deleteFromInventory(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("provide a valid ISBN to delete.");

            if (!_books.TryGetValue(isbn, out var b))
                throw new KeyNotFoundException("Book not found in inventory");

            _books.Remove(isbn);
            return b;
        }

        public List<Book> removeOutdated(int maxAge)
        {
            if (maxAge < 0)
                throw new ArgumentException("Max age can't be negative");

            var outdated = new List<Book>();

            foreach (var kv in _books)
            {
                var age = DateTime.Now.Year - kv.Value.pubdate.Year;

                if (age < 0)
                    continue;

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
