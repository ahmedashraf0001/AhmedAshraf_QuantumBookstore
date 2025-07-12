# Quantum Bookstore System

A simple online bookstore built in C# that manages different types of books and handles deliveries automatically.

## What It Does

This bookstore can handle three types of books:
- **Paper Books** - Physical books that get shipped to your address
- **EBooks** - Digital books sent to your email as files (PDF, DOCX, etc.)
- **Demo Books** - Free sample books for browsing (no delivery needed)

The cool part? Each book type knows how to deliver itself - paper books automatically use shipping, ebooks use email, and demo books don't need delivery at all.

## Key Features

- Add books to your inventory with details like ISBN, title, author, and price
- Buy books with automatic delivery to email or address
- Track stock for physical books 
- Remove old books that are past their prime
- Handle errors gracefully (like trying to buy books that don't exist)

## Design Patterns

### Strategy Pattern
Instead of writing messy if-else statements for different delivery types, I used the Strategy Pattern. Each book type picks its own delivery method:
- `EmailService` for digital books
- `ShippingService` for physical books  
- `NoDelivery` for demo books

This makes it super easy to add new delivery methods later without breaking existing code.

## SOLID Principles

The code follows good programming practices:
- **Single Responsibility** - Each class does one thing well
- **Open/Closed** - Easy to add new book types without changing existing code
- **Interface Segregation** - Small, focused interfaces that make sense
- **Dependency Inversion** - Classes depend on interfaces, not concrete implementations

## Usage Example

```csharp
// Set up the bookstore
var inventory = new Inventory();

// Add some books
var novel = new Paper_book("978-1234567890", "Great Novel", "John Doe", 
    29.99m, new DateTime(2023, 6, 15), 50);
var guide = new Ebook("978-0987654321", "Digital Guide", "Jane Smith", 
    19.99m, new DateTime(2024, 1, 10), FileType.Pdf);

inventory.AddToInventory(novel);
inventory.AddToInventory(guide);

// Buy a book
decimal cost = inventory.BuyBook("978-1234567890", 2, 
    "customer@email.com", "123 Main Street");
```

## Test Results

![Test Results](./test-results.png)

The system has been tested with various scenarios including successful purchases, inventory management, and all the error cases you can think of.

## Error Handling

![Test Results](./error-handling.png)

The system catches and handles common problems like:
- Invalid book information (empty titles, negative prices, future dates)
- Trying to buy books that don't exist
- Not enough stock for physical books
- Missing email or delivery address
- Invalid quantities

## Getting Started

1. Clone the repository
2. Open in Visual Studio
3. Build and run the project
4. Check the console for test results

The code is designed to be easily extensible - you can add new book types or delivery methods without breaking anything that already works.

---

*Built for the Fawry N² Dev Slope #10 Challenge*
