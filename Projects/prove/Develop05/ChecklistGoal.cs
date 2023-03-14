public class ChecklistGoal : Goal
{
    public int GoalNeeded { get; set; }
    public int GoalAccomplished { get; set; }
    public int GoalBonus { get; set; }
    public ChecklistGoal(string checkBox, string goalType, string name, string description, int points, bool status, int gAccomplished, int gNeeded, int bonus)
        : base(checkBox, goalType, name, description, points, status)
    {
        GoalAccomplished = gAccomplished;
        GoalNeeded = gNeeded;
        GoalBonus = bonus;
    }

    public override void Display()
    {
        Console.WriteLine($"{GoalCheckBox} - type: {GoalType} - {GoalName} - {GoalDescription} - {GoalPoints} points - {GoalStatus} ----- Currently completed: {GoalAccomplished}/{GoalNeeded} || bonus: {GoalBonus}");
    }
}