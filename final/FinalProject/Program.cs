using System;
using System.Collections.Generic;

// Abstract base class for library items
public abstract class LibraryItem
{
    // Encapsulated properties
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Year { get; private set; }

    // Constructor
    public LibraryItem(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    // Abstract method for displaying details of library items
    public abstract void Display();
}

// Book class which inherits from LibraryItem
public class Book : LibraryItem
{
    // Additional encapsulated property
    public string ISBN { get; private set; }

    // Constructor
    public Book(string title, string author, int year, string isbn) : base(title, author, year)
    {
        ISBN = isbn;
    }

    // Override Display method to provide specific implementation for books
    public override void Display()
    {
        Console.WriteLine($"Type: Book, Title: {Title}, Author: {Author}, Year: {Year}, ISBN: {ISBN}");
    }
}

// Library class for managing a collection of library items
public class Library
{
    // Encapsulated list of library items
    private List<LibraryItem> items;

    // Constructor
    public Library()
    {
        items = new List<LibraryItem>();
    }

    // Method to add items to the library
    public void AddItem(LibraryItem item)
    {
        items.Add(item);
    }

    // Method to display all items in the library
    public void DisplayItems()
    {
        Console.WriteLine("Library Inventory:");
        foreach (var item in items)
        {
            item.Display();
        }
    }

    // Method to search for a book by title
    public void SearchBookByTitle(string title)
    {
        bool found = false;
        foreach (var item in items)
        {
            if (item is Book book && book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Book found:");
                book.Display();
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("Book not found. Please make sure you entered the correct title.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = CreateLibraryWithBooks();
        RunLibraryMenu(library);
    }

    static Library CreateLibraryWithBooks()
    {
        Library library = new Library();

        // Add some items to the Library
        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "978-0743273565");
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", 1960, "978-0061120084");
        Book book3 = new Book("The Catcher in the Rye", "J.D. Salinger", 1951, "978-0316769488");

        library.AddItem(book1);
        library.AddItem(book2);


        return library;
    }

    static void RunLibraryMenu(Library library)
    {
        while (true)
        {
            // Display menu
            Console.WriteLine("\nLibrary Menu:");
           
            Console.WriteLine("1. Search for a book by title");
            Console.WriteLine("2. Add a new book");
            Console.WriteLine("3. Exit");

            // Get user input
            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            // Perform action based on user choice
            switch (choice)
            {
                
                case 1:
                    Console.Write("Enter the title of the book you want to search: ");
                    string searchTitle = Console.ReadLine();
                    library.SearchBookByTitle(searchTitle);
                    break;
                case 2:
                    Console.WriteLine("\nEnter details of the new book to add:");
                    Console.Write("Title: ");
                    string newTitle = Console.ReadLine();
                    Console.Write("Author: ");
                    string newAuthor = Console.ReadLine();
                    Console.Write("Year: ");
                    int newYear;
                    if (!int.TryParse(Console.ReadLine(), out newYear))
                    {
                        Console.WriteLine("Invalid input for year. Please enter a number.");
                        continue;
                    }
                    Console.Write("ISBN: ");
                    string newISBN = Console.ReadLine();

                    Book newBook = new Book(newTitle, newAuthor, newYear, newISBN);
                    library.AddItem(newBook);
                    Console.WriteLine("Book added successfully.");
                    break;
                case 3:
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }
        }
    }
}

