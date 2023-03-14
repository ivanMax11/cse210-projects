public class EternalGoal : Goal
{

    public EternalGoal(string checkBox, string goalType, string name, string description, int points, bool status)
        : base(checkBox, goalType, name, description, points, status)
    {
    }

    public override void Display()
    {
        Console.WriteLine($"{GoalCheckBox} - type: {GoalType} - {GoalName} - {GoalDescription} - {GoalPoints} points - {GoalStatus}");
    }
}