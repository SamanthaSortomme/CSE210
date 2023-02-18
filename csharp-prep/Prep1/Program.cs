using System;

class Program
{
    static void Main(string[] args)
    {
        string first;
        string last;
        //Console.WriteLine("Hello Prep1 World!");
        Console.Write("What is your first name? ");
        first = Console.ReadLine();
        Console.Write("What is your last name? ");
        last = Console.ReadLine();
        Console.Write($"\nYour name is {last}, {first} {last}.");
    }
}