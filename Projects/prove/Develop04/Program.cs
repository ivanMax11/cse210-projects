using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness App!");

        // Ciclo while para mostrar el menú hasta que el usuario elija salir
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter duration in seconds:");
                    int breathingDuration = Convert.ToInt32(Console.ReadLine());
                    BreathingActivity breathingActivity = new BreathingActivity(breathingDuration);
                    breathingActivity.Run();
                    break;
                case "2":
                    Console.WriteLine("Enter duration in seconds:");
                    int reflectionDuration = Convert.ToInt32(Console.ReadLine());
                    ReflectionActivity reflectionActivity = new ReflectionActivity(reflectionDuration);
                    reflectionActivity.Run();
                    break;
                case "3":
                    Console.WriteLine("Enter duration in seconds:");
                    int listingDuration = Convert.ToInt32(Console.ReadLine());
                    ListingActivity listingActivity = new ListingActivity(listingDuration);
                    listingActivity.Run();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness App!");
    }
}


