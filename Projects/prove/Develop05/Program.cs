using System;

class Program
{
    static void Main(string[] args)
    {
        GoalTracker goalTracker = new GoalTracker();
        string fileName = "goals.txt";

        while (true)
        {
            Console.Clear();
            Console.Write("The current user score is: ");
            goalTracker.ShowScore();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Select a choice from the menu: ");
                    Console.WriteLine("The types of Goals are: ");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");

                    Console.Write("Which type of goal would you like to create?: ");
                    string goalType = Console.ReadLine();

                    Console.Write("What is the name of your goal?: ");
                    string goalName = Console.ReadLine();

                    Console.Write("Enter the goal description: ");
                    string goalDescription = Console.ReadLine();

                    Console.Write("Enter the goal points: ");
                    int goalPoints = int.Parse(Console.ReadLine());

                    //Console.WriteLine("Enter the goal status (true/false):");
                    bool goalStatus = false;

                    string goalCheckBox = "[ ]";

                    if (goalType == "1")
                    {
                        goalTracker.AddGoal(new SimpleGoal(goalCheckBox, goalType, goalName, goalDescription, goalPoints, goalStatus));
                    }
                    else if (goalType == "2")
                    {
                        goalTracker.AddGoal(new EternalGoal(goalCheckBox, goalType, goalName, goalDescription, goalPoints, goalStatus));
                    }
                    else if (goalType == "3")
                    {
                        int GoalAccomplished = 0;
                        Console.Write("Enter the goal target: ");
                        int GoalNeeded = int.Parse(Console.ReadLine());

                        Console.Write("Enter the goal Bonus: ");
                        int GoalBonus = int.Parse(Console.ReadLine());
                        goalTracker.AddGoal(new ChecklistGoal(goalCheckBox, goalType, goalName, goalDescription, goalPoints, goalStatus, GoalAccomplished, GoalNeeded, GoalBonus));
                    }
                    break;

                case 2:
                    Console.Clear();
                    goalTracker.ShowGoals();
                    Console.Write("Enter to continue: ");
                    Console.ReadLine();
                    break;
                case 3:
                    goalTracker.SaveGoals(fileName);
                    Console.WriteLine($"Goals saved to file: {fileName}");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                case 4:
                    goalTracker.LoadGoals(fileName);
                    Console.WriteLine($"Goals loaded from file: {fileName}");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    goalTracker.ShowGoals();
                    Console.WriteLine("Enter the goal index:");
                    int index = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine("Is done the goal?: (true/false):");
                    bool status = bool.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the goal type:");
                    Console.WriteLine("1. Simple");
                    Console.WriteLine("2. Eternal");
                    Console.WriteLine("3. Check List");
                    string gtype = Console.ReadLine();


                    goalTracker.UpdateGoal(index, status, gtype);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}