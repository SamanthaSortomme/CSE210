using System;
using System.Text.RegularExpressions;

static class Globals
{
    public static int _totalPoints = 0;
}
class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        List<Goal> goals = new List<Goal>();
        List<Goal> archivedGoals = new List<Goal>();
        while (!quit)
        {
            int selection = SelectOption();
            switch (selection)
            {
                case 1:
                    {
                        goals.Add(CreateGoal());
                        break;
                    }
                case 2:
                    {
                        ListGoals(goals, "Active");
                        break;
                    }
                case 3:
                    {
                        RecordEvent(goals);
                        break;
                    }
                case 4:
                    {
                        SaveGoals(goals, archivedGoals);
                        break;
                    }
                case 5:
                    {
                        LoadGoals(goals, archivedGoals);
                        break;
                    }
                case 6:
                    {
                        ArchiveGoals(goals, archivedGoals);
                        break;
                    }
                case 7:
                    {
                        ListGoals(archivedGoals, "Archived");
                        break;
                    }
                case 8:
                    {
                        quit = true;
                        break;
                    }
                default:
                    {
                        Console.Write("Undeveloped option detected. please try again. :'(");
                        break;
                    }
            }
        }
    }


    static int SelectOption()
    {
        string options = """
Menu Options:
  1. Create New Goal        
  2. List Goals
  3. Record Event
  4. Save Goals
  5. Load Goals
  6. Archive Goals
  7. View Archived Goals
  8. Quit
Select an option from the menu: 
""";
        int optionCount = 8;
        int selection = GetConsoleInteger(options, optionCount);
        return selection;
    }

    static int GetConsoleInteger(string question, int range = 0)
    {
        while (true)
        {
            Console.Write(question);
            try
            {
                int selection = int.Parse(Console.ReadLine());
                if (range != 0)
                {
                    if (selection > 0 && selection <= range)
                    {
                        return selection;
                    }
                    else
                    {
                        Console.Write("please enter a valid number\n");
                    }
                }
                else
                {
                    return selection;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    static Goal CreateGoal()
    {
        string options = """
The types of Goals are:
1. Simple Goal       - A one time goal
2. Eternal Goal     - A continuous goal
3. Checklist Goal   - A multi-event goal
What type of goal do you want to create? 
""";
        int optionCount = 3;

        int selection = GetConsoleInteger(options, optionCount);
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("Give a description of this goal.");
        string description = Console.ReadLine();
        int points = GetConsoleInteger("How many points do you want to assign to this goal? ");
        switch (selection)
        {
            case 1:
                {
                    SimpleGoal newGoal = new SimpleGoal("Simple", name, points, description);
                    return newGoal;
                }
            case 2:
                {
                    EternalGoal newGoal = new EternalGoal("Eternal", name, points, description);
                    return newGoal;
                }
            case 3:
                {
                    int goalCount = GetConsoleInteger("How many times must this goal be logged? ");
                    int bonus = GetConsoleInteger("How many points are received upon completion? ");
                    ChecklistGoal newGoal = new ChecklistGoal("Checklist", name, points, description, goalCount, bonus);
                    return newGoal;
                }
            default:
                {
                    Console.Write("Something has gone horribly wrong. You have managed to find an option that is not available.");
                    return null;
                }
                // need to create default case... not sure what it should be at this point. good luck future me.
        }

    }

    static void ListGoals(List<Goal> goals, string status)
    {
        Console.Write($"Your {status} goals are:\n");
        int item = 1;
        foreach (Goal goal in goals)
        {
            goal.ListGoal(item);
            item++;
        }
        Console.Write($"\nYou have earned a total of {Globals._totalPoints} points.\n");
    }
    static void RecordEvent(List<Goal> goals)
    {
        int option = GetConsoleInteger("Which goal do you want to record? ", goals.Count()) - 1;

        if (!goals[option].GetCompleted())
        {
            goals[option].SetGoalCompleted();
            Globals._totalPoints += goals[option].GetPoints();
        }
        else
        {
            Console.Write($"This goal has already been completed. No additional points can be scored, you cheaty cheater.\n");
        }

    }

    // creatve: delete and archive completed goals have a archived list

    static void SaveGoals(List<Goal> goals, List<Goal> archivedGoals)
    {
        Console.Write("Enter the file name: ");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(Globals._totalPoints);
            foreach (Goal goal in goals)
            {
                string goalText = goal.Stringify();
                outputFile.WriteLine(goalText);
            }
            foreach (Goal goal in archivedGoals)
            {
                string goalText = goal.Stringify();
                outputFile.WriteLine(goalText);
            }
        }
    }

    static void LoadGoals(List<Goal> goals, List<Goal> archivedGoals)
    {
        goals.Clear();
        archivedGoals.Clear();
        Console.Write("Enter the file name: ");
        string fileName = Console.ReadLine();
        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            // string lines = System.IO.File.ReadAllLines(fileName);
            {
                string line = sr.ReadLine();
                Globals._totalPoints = int.Parse(line);

                while ((line = sr.ReadLine()) != null)
                {
                    string[] result = Regex.Split(line, "[,]{1}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    result[2] = Regex.Replace(result[2], "\"", "");
                    result[4] = Regex.Replace(result[4], "\"", "");
                    switch (result[1])
                    {
                        case "Simple":
                            {
                                bool archived = bool.Parse(result[0]);
                                string type = result[1];
                                string name = result[2];
                                int points = int.Parse(result[3]);
                                string descript = result[4];
                                bool complete = bool.Parse(result[5]);
                                if (!archived)
                                {
                                    goals.Add(new SimpleGoal(archived, type, name, points, descript, complete));
                                }
                                else
                                {
                                    archivedGoals.Add(new SimpleGoal(archived, type, name, points, descript, complete));
                                }
                                break;
                            }
                        case "Eternal":
                            {
                                bool archived = bool.Parse(result[0]);
                                string type = result[1];
                                string name = result[2];
                                int points = int.Parse(result[3]);
                                string descript = result[4];
                                bool complete = bool.Parse(result[5]);
                                int timesCompleted = int.Parse(result[6]);
                                if (!archived)
                                {
                                    goals.Add(new EternalGoal(archived, type, name, points, descript, complete, timesCompleted));
                                }
                                else
                                {
                                    archivedGoals.Add(new EternalGoal(archived, type, name, points, descript, complete, timesCompleted));
                                }
                                break;
                            }
                        case "Checklist":
                            {
                                bool archived = bool.Parse(result[0]);
                                string type = result[1];
                                string name = result[2];
                                int points = int.Parse(result[3]);
                                string descript = result[4];
                                bool complete = bool.Parse(result[5]);
                                int goalCount = int.Parse(result[7]);
                                int bonus = int.Parse(result[8]);
                                int timesCompleted = int.Parse(result[6]);
                                if (!archived)
                                {
                                    goals.Add(new ChecklistGoal(archived, type, name, points, descript, complete, goalCount, bonus, timesCompleted));
                                }
                                else
                                {
                                    archivedGoals.Add(new ChecklistGoal(archived, type, name, points, descript, complete, goalCount, bonus, timesCompleted));
                                }
                                break;
                            }
                        default:
                            {
                                Console.Write($"an error occured while loading goal from file. this error occured in the line containing: {result}\n");
                                break;
                            }
                    }
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void ArchiveGoals(List<Goal> goals, List<Goal> archivedGoals)
    {

        for (int i = goals.Count - 1; i > -1; i--)
        {
            if (goals[i].GetCompleted())
            {
                goals[i].SetArchived();
                archivedGoals.Add(goals[i]);
                goals.RemoveAt(i);
            }

        }
    }

    // static Dictionary<string, string> ReadFile(string fileName)
    // {
    //     Dictionary<string, string> textDictionary = new Dictionary<string, string>();
    //     List<string> outputFile = File.ReadLines(fileName).ToList();

    //     foreach (string line in outputFile)
    //     {
    //         string[] result = Regex.Split(line, "[,]{1}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
    //         result[1] = Regex.Replace(result[1], "\"", "");
    //         textDictionary.Add(result[0], result[1]);
    //     }

    //     return textDictionary;
    // }



}