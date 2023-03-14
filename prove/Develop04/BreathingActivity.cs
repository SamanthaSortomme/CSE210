class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        SetActivityType("Breating");
        SetDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.\n");
    }


    public void StartActivity()
    {
        int count = 5;
        Startup();

        Console.Write("\nbegin in ");
        for (int i = 3; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write($"\b \b");
        }

        while (_watch.ElapsedMilliseconds < GetDuration() * 1000)
        {
            _watch.Start();
            Console.Write("\n\nInhale slowly ");
            for (int i = count; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write($"\b \b");
            }
            _watch.Stop();
            if (_watch.ElapsedMilliseconds >= GetDuration() * 1000)
            {
                break;
            }
            _watch.Start();

            Console.Write("\n\nExhale slowly ");
            for (int i = count; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write($"\b \b");
            }
            _watch.Stop();
        }
        EndingMessage();
    }

}
