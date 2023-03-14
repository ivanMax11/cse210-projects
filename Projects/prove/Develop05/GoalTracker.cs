using System;
using System.IO;

class GoalTracker
{
    private List<Goal> _goalsList;
    private int _userScore;
    public GoalTracker()
    {
        _goalsList = new List<Goal>();
    }

    public void AddGoal(Goal data)
    {
        _goalsList.Add(data);
    }

    public void UpdateGoal(int index, bool status, string gtype)
    {
        var goal = _goalsList[index];

        if (status == true && gtype == "1")
        {
            goal.GoalCheckBox = "[X]";
            _userScore += goal.GoalPoints;
        }
        else if (status == false && gtype == "1")
        {
            goal.GoalCheckBox = "[ ]";
            _userScore -= goal.GoalPoints;
        }
        else if (status == true && gtype == "2")
        {
            goal.GoalCheckBox = "[ ]";
            _userScore += goal.GoalPoints;
        }
        else if (status == false && gtype == "2")
        {
            goal.GoalCheckBox = "[ ]";
            _userScore -= goal.GoalPoints;
        }
        else if (status == true && gtype == "3")
        {
            if (goal is ChecklistGoal)
            {
                var goalChecklist = (ChecklistGoal)goal;
                goalChecklist.GoalAccomplished += 1;
                _userScore += goal.GoalPoints;

                if (goalChecklist.GoalAccomplished == goalChecklist.GoalNeeded)
                {
                    _userScore += goalChecklist.GoalBonus;
                    goalChecklist.GoalCheckBox = "[x]";
                }
            }
        }
        else if (status == false && gtype == "3")
        {
            if (goal is ChecklistGoal)
            {
                var goalChecklist = (ChecklistGoal)goal;
                goalChecklist.GoalAccomplished -= 1;
                _userScore -= goal.GoalPoints;
            }
        }
        else
        {
            Console.WriteLine("Error, check again the Index/Status/Goal Type");
        }
    }


    public void ShowGoals()
    {
        Console.WriteLine("List of Goals:");
        int index = 1;
        foreach (Goal data in _goalsList)
        {
            Console.Write($"{index}. ");
            data.Display();
            index++;
        }
        Console.WriteLine();
    }

    public void ShowScore()
    {
        Console.WriteLine(_userScore);
    }


    public void SaveGoals(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_userScore);
            foreach (Goal goal in _goalsList)
            {
                if (goal.GoalType == "3")
                {
                    if (goal is ChecklistGoal)
                    {
                        var goalChecklist = (ChecklistGoal)goal;
                        writer.WriteLine($"{goal.GoalCheckBox},{goal.GoalType},{goal.GoalName},{goal.GoalDescription},{goal.GoalPoints},{goal.GoalStatus},{goalChecklist.GoalAccomplished},{goalChecklist.GoalNeeded},{goalChecklist.GoalBonus}");
                    }
                }
                else
                {
                    writer.WriteLine($"{goal.GoalCheckBox},{goal.GoalType},{goal.GoalName},{goal.GoalDescription},{goal.GoalPoints},{goal.GoalStatus}");
                }
            }
        }
    }

    public void LoadGoals(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            _userScore = int.Parse(reader.ReadLine());
            while (!reader.EndOfStream)
            {
                string[] goalData = reader.ReadLine().Split(',');

                int goalType = int.Parse(goalData[1]);

                if (goalType == 1)
                {
                    AddGoal(new SimpleGoal(goalData[0], goalData[1], goalData[2], goalData[3], int.Parse(goalData[4]), bool.Parse(goalData[5])));
                }
                else if (goalType == 2)
                {
                    AddGoal(new EternalGoal(goalData[0], goalData[1], goalData[2], goalData[3], int.Parse(goalData[4]), bool.Parse(goalData[5])));
                }
                else if (goalType == 3)
                {
                    AddGoal(new ChecklistGoal(goalData[0], goalData[1], goalData[2], goalData[3], int.Parse(goalData[4]), bool.Parse(goalData[5]), int.Parse(goalData[6]),int.Parse(goalData[7]),int.Parse(goalData[8])));
                }
            }
        }
    }
}