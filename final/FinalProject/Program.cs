using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        Console.Write("Enter your full name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your ID: ");
        int id = int.Parse(Console.ReadLine());

        Library library = new Library(name, id);
        int choice = 0;

        do {
            Console.WriteLine("1. Borrow a book");
            Console.WriteLine("2. Return a book");
            Console.WriteLine("3. Show history");
            Console.WriteLine("4. Exit");

            Console.Write("Select an option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice) {
                case 1:
                    Console.Write("Enter the title of the book you want to borrow: ");
                    string bookTitle = Console.ReadLine();
                    Console.Write("Enter the author of the book you want to borrow: ");
                    string bookAuthor = Console.ReadLine();
                    library.Borrow(bookTitle, bookAuthor);
                    Console.WriteLine($"You have borrowed the book '{bookTitle}' by '{bookAuthor}'.");
                    break;

                case 2:
                    Console.Write("Enter the title of the book you want to return: ");
                    bookTitle = Console.ReadLine();
                    library.Return(bookTitle);
                    break;

                case 3:
                    library.ShowHistory();
                    break;
            }
        } while (choice != 4);
    }
}


