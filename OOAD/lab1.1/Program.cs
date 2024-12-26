using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace OOAD.lab1{
    class Book 
    {
        public string title { get; set; }
        public string author { get; set; }
        public int year { get; set; }

        public Book(string title, string author, int year)
        {
            this.title = title;
            this.author = author;
            this.year = year;
        }
    }

    class BookManager
    {
        private List<Book> books ;
        private readonly string filePath;

        public BookManager(string filePath)
        {
            this.filePath = filePath;
            books = new List<Book>();
            Load();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Load();
        }

        public List<Book> SearchByTitle(string title)
        {
            return books.Where(b => b.title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books.Where(b => b.author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(books);
            File.WriteAllText(filePath, json);
        }

        public void Load()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                books = JsonSerializer.Deserialize<List<Book>>(json);
            }
        }

    }

    class Program
    {
        static void Main()
        {
            BookManager manager = new BookManager("books.dat");

            while(true)
            {
                Console.WriteLine("\nBook Management System");
                Console.WriteLine("1. Add new book");
                Console.WriteLine("2. Search books by title");
                Console.WriteLine("3. Search books by author");
                Console.WriteLine("4. Exit");

                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        Console.Write("Enter book title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter book author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter book year: ");
                        int year = int.Parse(Console.ReadLine());
                        manager.AddBook(new Book(title, author, year));
                        Console.WriteLine("Book added successfully!");
                        break;
                    case "2":
                        Console.Write("Enter title to search: ");
                        string titleSearch = Console.ReadLine();
                        var titleResults = manager.SearchByTitle(titleSearch);
                        if (titleResults.Any())
                        {
                            Console.WriteLine("Search found: ");
                            foreach (var book in titleResults)
                            {
                                Console.WriteLine($"- {book.title} by {book.author} ({book.year})");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No book found!");
                        }
                        break;
                    case "3":
                        Console.Write("Enter author to search: ");
                        string authorSearch = Console.ReadLine();
                        var authorResults = manager.SearchByAuthor(authorSearch);
                        if (authorResults.Any())
                        {
                            Console.WriteLine("Search found: ");
                            foreach (var book in authorResults)
                            {
                                Console.WriteLine($"- {book.title} by {book.author} ({book.year})");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No book found!");
                        }
                        break;
                    case "4":
                        manager.Save();
                        Console.WriteLine("Data saved. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again!");
                        break;
                }
            }
        }
    }
}
