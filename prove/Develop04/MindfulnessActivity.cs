using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;


class MindfulnessActivity
{
    protected int durationInSeconds;
    protected string name;
    protected string description;

    public virtual void Run()
    {
        Console.WriteLine($"Starting {name} activity");
        Console.WriteLine(description);

        Console.WriteLine("Get ready to begin...");
        Pause(3);

        Console.WriteLine("Starting in:");
        for (int i = 3; i >= 1; i--)
        {
            Console.WriteLine(i);
            Pause(1);
        }
        
        // Implement activity logic here

        Pause(5);
    }

    protected void Pause(int seconds)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        while (stopwatch.ElapsedMilliseconds < seconds * 1000) { }
        stopwatch.Stop();
    }
}