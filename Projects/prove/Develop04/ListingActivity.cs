using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class ListingActivity : MindfulnessActivity
{
    private string[] prompts = new string[] {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int durationInSeconds)
    {
        name = "Listing";
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        this.durationInSeconds = durationInSeconds;
    }

    public override void Run()
    {
        base.Run();

        var stopwatch = Stopwatch.StartNew();
List<string> itemList = new List<string>();

while (stopwatch.Elapsed.TotalSeconds < durationInSeconds)
{
    Random random = new Random();
    string chosenCategory = prompts[random.Next(prompts.Length)];
    Console.WriteLine($"{chosenCategory}");

    Console.Write("Enter an item to add to the list (or 'done' to finish): ");
    string item = Console.ReadLine();

    if (item.ToLower() == "done")
    {
        break;
    }

    itemList.Add(item);
}

Console.WriteLine($"You listed {itemList.Count} items:");
foreach (string item in itemList)
{
    Console.WriteLine($"- {item}");
}

Pause(3);
    }
}