using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
   static void Main(string[] args)
    {
        List<Tuple<string, string, DateTime>> journal = new List<Tuple<string, string, DateTime>>();
        Random rnd = new Random();
        string[] questions = new string[] { "How do you felt today?", "What are the most significant things that you have learned today?", "Write some scripture you have liked in your study",
        "Write your thoughts about your life in the Gospel" };

        while (true)
        {
            Console.WriteLine("Welcome to your Journal Iván. Please select an option:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    int index = rnd.Next(questions.Length);
                    Console.WriteLine("You selected 'Write'");
                    Console.WriteLine(questions[index]);
                    string answer = Console.ReadLine();
                    journal.Add(Tuple.Create(questions[index], answer, DateTime.Now));
                    break;
                case "2":
                    Console.WriteLine("You selected 'Display'");
                    foreach (var entry in journal)
                    {
                        Console.WriteLine("Question: " + entry.Item1);
                        Console.WriteLine("Answer: " + entry.Item2);
                        Console.WriteLine("Date/Time: " + entry.Item3);
                    }
                    break;
            case "3":
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
                    break;
                case "4":
                    Console.WriteLine("You selected 'Save'");
                Console.WriteLine("Enter the name of the file to save");
                string saveFile = Console.ReadLine();
                using (StreamWriter writer = new StreamWriter(saveFile))
                {
                    string json = System.Text.Json.JsonSerializer.Serialize(journal);
                    writer.Write(json);
                }
                    break;
                case "5":
                    Console.WriteLine("You selected 'Quit'");
                    return;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
                }
            }            
        }
    }    

