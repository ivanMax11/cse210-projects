using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class ReflectionActivity : MindfulnessActivity
{
    protected const int ReflectionDurationSeconds = 15;
    private List<string> reflectionPrompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> reflectionQuestions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int durationInSeconds)
    {
        name = "Reflection";
        description = "This activity will help you reflect on your thoughts and feelings.";
        this.durationInSeconds = durationInSeconds;
    }

    public override void Run()
    {
        base.Run();

        Console.WriteLine("Starting reflection period...");

        int elapsedSeconds = 0;
        while (elapsedSeconds < durationInSeconds)
        {
            //Select a ramdom reflecting prompt and show to the user 
            Console.WriteLine("Press enter when you have some thing in mind");
            string reflectionPrompt = reflectionPrompts[new Random().Next(reflectionPrompts.Count)];
            Console.WriteLine(reflectionPrompt);
            
            Console.ReadLine(); // White to the user press enter

            //Select a randm reflecting question and show to the user
            string reflectionQuestion = reflectionQuestions[new Random().Next(reflectionQuestions.Count)];
            Console.WriteLine(reflectionQuestion);
            Pause(10);

            elapsedSeconds += 10; 
        }

        Console.WriteLine($"Great job! You completed the {name} activity for {durationInSeconds} seconds");
    }
}