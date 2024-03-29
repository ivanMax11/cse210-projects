using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Tuple<string, string, DateTime>> journal = new List<Tuple<string, string, DateTime>>();
    private Random rnd = new Random();
    private string[] questions = new string[] { "How do you felt today?", "What are the most significant things that you have learned today?", "Write some scripture you have liked in your study",
    "Write your thoughts about your life in the Gospel" };

    public void Write()
    {
        int index = rnd.Next(questions.Length);
        Console.WriteLine("You selected 'Write'");
        Console.WriteLine(questions[index]);
        string answer = Console.ReadLine();
        journal.Add(Tuple.Create(questions[index], answer, DateTime.Now));
    }

    public void Display()
    {
        Console.WriteLine("You selected 'Display'");
        foreach (var entry in journal)
        {
            Console.WriteLine("Question: " + entry.Item1);
            Console.WriteLine("Answer: " + entry.Item2);
            Console.WriteLine("Date/Time: " + entry.Item3);
        }
    }

    public void Load()
    {
        Console.WriteLine("You selected 'Load'");
        Console.WriteLine("Enter the name of the file to open");
        string openFile = Console.ReadLine();
        if (File.Exists(openFile))
        {
            using(StreamReader reader = new StreamReader(openFile))
            {
                string json = reader.ReadToEnd();
                journal = System.Text.Json.JsonSerializer.Deserialize<List<Tuple<string, string, DateTime>>>(json);
            }
        }
        else
        {
            Console.WriteLine("File not found. Please try again.");
        }
    }

    public void Save()
    {
        Console.WriteLine("You selected 'Save'");
        Console.WriteLine("Enter the name of the file to save");
        string saveFile = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(saveFile))
        {
            string json = System.Text.Json.JsonSerializer.Serialize(journal);
            writer.Write(json);
        }
    }

    public void Quit()
    {
        Console.WriteLine("You selected 'Quit'");
        Environment.Exit(0);
    }
}

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