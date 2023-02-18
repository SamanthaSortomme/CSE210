using System;

class Program
{
    static void Main(string[] args)
    {
        int numRange = 25;
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(0, numRange + 1);
        int guess;
        int guessCount = 0;
        string cont = "yes";
        do
        {
            Console.Write($"pick a number between 0 and {numRange}: ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;
            if (guess < magicNumber)
            {
                Console.WriteLine("Too low Joe.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Too high fry.");
            }
            else
            {
                Console.WriteLine($"You win, Jinn! only took you {guessCount} guesses! \nWant to play again?(yes/no) ");
                cont = Console.ReadLine();
                guessCount = 0;
            }
        } while (cont == "yes");
        Console.WriteLine("Good bye.");
    }
}