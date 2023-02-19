using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favNumber = PromptUserNumber();
        int squared = SquareNumber(favNumber);
        DisplayResult(name, squared);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        string name;
        Console.Write("Please enter your name. ");
        name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        int number;
        Console.Write("Please enter your favorite whole number. ");
        number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber(int number)
    {
        int squared = number * number;
        return squared;
    }

    static void DisplayResult(string name, int squared)
    {
        Console.Write($"{name}, the square of your number is {squared}");
    }

}