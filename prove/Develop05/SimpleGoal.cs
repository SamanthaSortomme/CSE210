class SimpleGoal : Goal
{




    public SimpleGoal(string goalType, string goalName, int points, string goalDescription) : base(goalType, goalName, points, goalDescription)
    {
    }

    public SimpleGoal(bool archived, string goalType, string goalName, int points, string goalDescription, bool completed) : base(archived, goalType, goalName, points, goalDescription, completed)
    {
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
        return $"{archived},{type},\"{name}\",{points},\"{descript}\",{completed}";
    }

    public override void ListGoal(int position)
    {
        string name = GetGoalName();
        int points = GetPoints();
        string descript = GetGoalDescription();
        char completed;
        if (GetCompleted())
        {
            completed = 'X';
        }
        else
        {
            completed = ' ';
        }

        Console.Write($"{position}. [{completed}] {name} ({descript}) worth {points} points\n");
    }


    public override void SetGoalCompleted()
    {
        SetCompleted();
    }
}