class ReflectingActivity : Activity
{
    private List<string> _startQuestions = new List<string>(new string[] {"Think of a time when you stood up for someone else.",
"Think of a time when you did something really difficult.",
"Think of a time when you helped someone in need.",
"Think of a time when you did something truly selfless."});

    private List<string> _followUpQuestions = new List<string>(new string[] {"Why was this experience meaningful to you?",
"Have you ever done anything like this before?",
"How did you get started?",
"How did you feel when it was complete?",
"What made this time different than other times when you were not as successful?",
"What is your favorite thing about this experience?",
"What could you learn from this experience that applies to other situations?",
"What did you learn about yourself through this experience?",
"How can you keep this experience in mind in the future?"});

    private bool[] _followUpQuestionsUsed = new bool[9];
    private bool[] _startQuestionsUsed = new bool[4];

    public ReflectingActivity()
    {
        SetActivityType("Reflecting");
        SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n");
    }

    public void StartActivity()
    {
        string question;
        Startup();
        question = ChooseQuestion(_startQuestions, _startQuestionsUsed);
        Console.Write($"{question}\n");
        Thread.Sleep(2000);
        while (_watch.ElapsedMilliseconds < GetDuration() * 1000)
        {
            question = ChooseQuestion(_followUpQuestions, _followUpQuestionsUsed);
            _watch.Start();
            Console.Write($"{question}\n");
            Spinner();
            _watch.Stop();
        }
        EndingMessage();

    }

    // private string ChooseStartingQuestion()
    // {
    //     Random rand = new Random();
    //     int selection;
    //     if (CheckQuestions(_startQuestionsUsed))
    //     {
    //         resetQuestions(_startQuestionsUsed);
    //     }
    //     do
    //     {
    //         selection = rand.Next(_startQuestions.Count);
    //         if (!_startQuestionsUsed[selection])
    //         {
    //             _startQuestionsUsed[selection] = true;
    //             return _startQuestions[selection];
    //         }
    //     } while (true);
    // }

    // private string ChooseFollowUpQuestion()
    // {
    //     Random rand = new Random();
    //     int selection;
    //     if (CheckQuestions(_startQuestionsUsed))
    //     {
    //         resetQuestions(_startQuestionsUsed);
    //     }
    //     do
    //     {
    //         selection = rand.Next(_followUpQuestions.Count);
    //         if (!_followUpQuestionsUsed[selection])
    //         {
    //             _followUpQuestionsUsed[selection] = true;
    //             return _followUpQuestions[selection];
    //         }
    //     } while (true);
    // }

}

//internal class ReflectingActivity  ADD THIS : Activity
// then you can quick fix and add all the lines