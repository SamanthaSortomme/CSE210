class ChecklistGoal : Goal
{
    private int _goalCount;
    private int _bonus;
    private int _timesCompleted = 0;

    public ChecklistGoal(string goalType, string goalName, int points, string goalDescription, int goalCount, int bonus) : base(goalType, goalName, points, goalDescription)
    {
        _goalCount = goalCount;
        _bonus = bonus;
    }

    public ChecklistGoal(bool archived, string goalType, string goalName, int points, string goalDescription, bool completed, int goalCount, int bonus, int timesCompleted) : base(archived, goalType, goalName, points, goalDescription, completed)
    {
        _goalCount = goalCount;
        _bonus = bonus;
        _timesCompleted = timesCompleted;
    }

    public void SetGoalCount(int goalCount)
    {
        _goalCount = goalCount;
    }
    public void SetBonus(int bonus)
    {
        _bonus = bonus;
    }
    public void SetTimesCompleted(int timesCompleted)
    {
        _timesCompleted = timesCompleted;
    }
    public int GetGoalCount()
    {
        return _goalCount;
    }
    public int GetBonus()
    {
        return _bonus;
    }
    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }

    public override int GetPoints()
    {
        if (base.GetCompleted())
        {
            return base.GetPoints() + _bonus;
        }
        else
        {
            return base.GetPoints();
        }
    }

    public override void SetGoalCompleted()
    {
        _timesCompleted++;
        if (_timesCompleted == _goalCount)
        {
            SetCompleted();
        }
    }

    public override string Stringify()
    {
        bool archived = GetArchived();
        string type = GetGoalType();
        string name = GetGoalName();
        int points = GetPoints();
        string descript = GetGoalDescription();
        bool completed = GetCompleted();
        if (completed)
        {
            points -= _bonus;// remove the added bonus points from the point base.
        }
        return $"{archived},{type},\"{name}\",{points},\"{descript}\",{completed},{_timesCompleted},{_goalCount},{_bonus}";
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
            points -= _bonus; // remove the added bonus points from the point base.
        }
        else
        {
            completed = ' ';
        }

        Console.Write($"{position}. [{completed}] {name} ({descript}) worth {points} points ({_bonus} points on completion) —— Currently completed: {_timesCompleted}/{_goalCount}\n");
    }

}