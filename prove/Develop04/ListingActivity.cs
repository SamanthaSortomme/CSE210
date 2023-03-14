class ListingActivity : Activity
{

    private List<string> _prompt = new List<string>(new string[] {"Who are people that you appreciate?",
"What are personal strengths of yours?",
"Who are people that you have helped this week?",
"When have you felt the Holy Ghost this month?",
"Who are some of your personal heroes?",
"Who did what to who for how many skittles?"});

    private bool[] _promptUsed = new bool[6];

    public ListingActivity()
    {
        SetActivityType("Listing");
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }
    public void StartActivity()
    {
        Startup();
        string question = ChooseQuestion(_prompt, _promptUsed);
        Console.Write($"\n--- {question} ---\n");
        Thread.Sleep(1000);
        FinalCountDown();
        while (_watch.ElapsedMilliseconds < GetDuration() * 1000)
        {
            _watch.Start();
            Console.Write($"\n>");
            Console.ReadLine();
            _watch.Stop();
        }
        EndingMessage();
    }

    private void FinalCountDown()
    {
        Console.Write("You may begin in:");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

}


