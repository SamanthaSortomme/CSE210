using System;
using System.Diagnostics;

class Activity //ctrl shift R generate constructor
{
    // declare attributes before properties the constructors methods getters setters
    private string _activityType; //property
    private string _activityDescription; //property
    private int _duration; //property
    protected Stopwatch _watch = new Stopwatch();

    //protected Random _random = new Random();

    public Activity() { }

    public Activity(string activityType, string activityDescription, int duration)
    {
        _activityType = activityType;
        _activityDescription = activityDescription;
        _duration = duration;
    }

    protected string GetActivityType()
    {
        return _activityType;
    }

    protected string GetDescription()
    {
        return _activityType;
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected void SetActivityType(string type)
    {
        _activityType = type;
    }

    protected void SetDescription(string description)
    {
        _activityDescription = description;
    }

    protected void SetDuration(int duration)
    {
        _duration = duration;
    }

    public void Welcome()
    {
        Console.Clear();
        Console.Write($"Welcome to the Jungle, we've got fun and games. By Jungle we mean this program and by fun and games we mean {_activityType} and other \"relaxing\" activities.\n");
    }

    public void EndingMessage()
    {
        Console.Write($"\nWell done thou good and faithful servant! Thou hast rested {_watch.ElapsedMilliseconds / 1000} seconds from your cares and labors.\n\n");
    }

    public void Animation()
    {
        string[] kirbyDance = { "(>'-')>", "<('-'<)", "(>'-')>", "<('-'<)", "v('-')v", "^('-')^", "v('-')v", "^('-')^", "\\(^-^)/" };

        Console.Clear();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < kirbyDance.Length - 1; j++)
            {
                Console.Write(kirbyDance[j]);
                Thread.Sleep(250);
                Console.Write($"\b\b\b\b\b\b\b       \b\b\b\b\b\b\b");
            }
        }
        Console.Write($"All Done!{kirbyDance[8]}\n");
        Thread.Sleep(1000);
    }

    public void Spinner()
    {
        string[] spinnerStates = { "|", "/", "—", "\\" };
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < spinnerStates.Length; j++)
            {
                Console.Write(spinnerStates[j]);
                Thread.Sleep(125);
                Console.Write($"\b \b");
            }
        }
        Console.Write($"\n");
    }


    public void SpinningHead()
    {
        string[] spinnerStates = { "(・_・)", "(/・_)", "(//・)", "(\\//)", "(・\\/)", "(_・\\)" };

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < spinnerStates.Length; j++)
            {
                Console.Write(spinnerStates[j]);
                Thread.Sleep(125);
                Console.Write($"\b\b\b\b\b     \b\b\b\b\b");
            }
        }
        Console.Write($"{spinnerStates[0]}\n\n");
    }

    public void DisplayPrompt()
    {
        Console.Write(_activityDescription);
    }

    public void Startup()
    {
        Welcome();
        while (true) // loop until the user gives a whole number response
        {
            Console.Write("\nHow long do you wish to to perform this activity (in seconds)");
            try
            {
                int duration = int.Parse(Console.ReadLine());
                _duration = duration;
                break;
            }
            catch (FormatException e)
            {
                Console.Write(e.Message);
            }
        }
        Animation();
        Console.Clear();
        DisplayPrompt();
        Thread.Sleep(2000);
    }

    protected string ChooseQuestion(List<string> questions, bool[] used)
    {
        Random rand = new Random();
        int selection;
        if (CheckQuestions(used))
        {
            resetQuestions(used);
        }
        do
        {
            selection = rand.Next(questions.Count);
            if (!used[selection])
            {
                used[selection] = true;
                return questions[selection];
            }
        } while (true);
    }

    private bool CheckQuestions(bool[] questionsUsed)
    {
        foreach (bool question in questionsUsed)
        {
            if (!question)
            {
                return false;
            }
        }
        return true;
    }

    private void resetQuestions(bool[] usedQuestions)
    {
        for (int i = 0; i < usedQuestions.Length; i++)
        {
            usedQuestions[i] = false;
        }
    }

}


