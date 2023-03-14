public abstract class Goal
{
    public string GoalType { get; set; }
    public string GoalCheckBox { get; set; }
    public string GoalName { get; set; }
    public string GoalDescription { get; set; }
    public int GoalPoints { get; set; }
    public bool GoalStatus { get; set; }

    public Goal(string checkBox, string goalType, string name, string description, int points, bool status)
    {
        GoalCheckBox = checkBox;
        GoalType = goalType;
        GoalName = name;
        GoalDescription = description;
        GoalPoints = points;
        GoalStatus = status;
    }


    public abstract void Display();

    public override string ToString()
    {
        return $"{GoalCheckBox}, {GoalType}, {GoalName}, {GoalDescription}, {GoalPoints}, {GoalStatus}";
    }
}