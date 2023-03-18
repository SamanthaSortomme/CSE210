class EternalGoal : Goal
{
    private int _timesCompleted = 0;

    public EternalGoal(string goalType, string goalName, int points, string goalDescription) : base(goalType, goalName, points, goalDescription)
    {
    }

    public EternalGoal(bool archived, string goalType, string goalName, int points, string goalDescription, bool completed, int timesCompleted) : base(archived, goalType, goalName, points, goalDescription, completed)
    {
        _timesCompleted = timesCompleted;
    }

    public override void SetGoalCompleted()
    {
        _timesCompleted++;
    }

    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }
    public override int GetPoints()
    {
        return base.GetPoints();
    }

    public override string Stringify()
    {
        bool archived = GetArchived();
        string type = GetGoalType();
        string name = GetGoalName();
        int points = GetPoints();
        string descript = GetGoalDescription();
        bool completed = GetCompleted();
        return $"{archived},{type},\"{name}\",{points},\"{descript}\",{completed},{_timesCompleted}";
    }

    public override void ListGoal(int position)
    {
        string name = GetGoalName();
        int points = GetPoints();
        string descript = GetGoalDescription();

        Console.Write($"{position}. [ ] {name} ({descript}) worth {points} points —— Number of times completed: {_timesCompleted} \n");
    }

}