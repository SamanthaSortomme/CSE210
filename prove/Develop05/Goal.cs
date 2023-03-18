public abstract class Goal
{

    private bool _archived = false;
    private string _goalType;
    private string _goalName;
    private int _points;
    private string _goalDescription;
    private bool _completed = false;

    protected Goal(string goalType, string goalName, int points, string goalDescription)
    {
        _goalType = goalType;
        _goalName = goalName;
        _points = points;
        _goalDescription = goalDescription;
    }

    protected Goal(bool archived, string goalType, string goalName, int points, string goalDescription, bool completed)
    {
        _archived = archived;
        _goalType = goalType;
        _goalName = goalName;
        _points = points;
        _goalDescription = goalDescription;
        _completed = completed;

    }
    public void SetArchived()
    {
        _archived = true;
    }
    public void SetGoalType(string type)
    {
        _goalType = type;
    }
    public void SetGoalName(string name)
    {
        _goalName = name;
    }
    public void SetPoints(int points)
    {
        _points = points;
    }

    public void SetGoalDescription(string description)
    {
        _goalDescription = description;
    }

    public virtual bool SetCompleted()
    {
        _completed = true;
        return false; // the only time this should return true is if a checklist goal has been finished.
    }
    public bool GetArchived()
    {
        return _archived;
    }
    public bool GetCompleted()
    {
        return _completed;
    }

    public string GetGoalType()
    {
        return _goalType;
    }

    protected string GetGoalName()
    {
        return _goalName;
    }

    public string GetGoalDescription()
    {
        return _goalDescription;
    }
    public abstract string Stringify(); // formats goal to save to text file


    public abstract void ListGoal(int position);

    public virtual int GetPoints()
    {
        return _points;
    }

    public abstract void SetGoalCompleted();
}