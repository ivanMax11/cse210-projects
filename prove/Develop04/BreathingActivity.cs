using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;


class BreathingActivity : MindfulnessActivity
{
    private const int PauseSecondsBeforeStart = 7;
    private const int InhalationSeconds = 4;
    private const int ExhalationSeconds = 6;

    public BreathingActivity(int durationInSeconds)
    {
        name = "Breathing";
        description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        this.durationInSeconds = durationInSeconds;
    }

    public override void Run()
    {
        base.Run();

        Console.WriteLine("Get ready to begin...");
        Pause(PauseSecondsBeforeStart);

        int numBreaths = durationInSeconds / (InhalationSeconds + ExhalationSeconds);

        for (int i = 1; i <= numBreaths; i++)
        {
            Console.WriteLine($"Breath {i}: Inhale for {InhalationSeconds} seconds");
            Pause(InhalationSeconds);

            Console.WriteLine($"Breath {i}: Exhale for {ExhalationSeconds} seconds");
            Pause(ExhalationSeconds);
        }

        Console.WriteLine($"Great job! You completed the {name} activity for {durationInSeconds} seconds");
    }
}