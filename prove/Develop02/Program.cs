using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Welcome to your Journal Iván. Please select an option:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    journal.Write();
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    journal.Load();
                    break;
                case "4":
                    journal.Save();
                    break;
                case "5":
                    journal.Quit();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}