using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction myFraction = new Fraction();

        Console.WriteLine($"{myFraction.GetFractionString()}\n{myFraction.GetDecimalValue()}");

        myFraction.setNumerator(5);

        Console.WriteLine($"{myFraction.GetFractionString()}\n{myFraction.GetDecimalValue()}");

        myFraction.setNumerator(3);
        myFraction.setDenominator(4);

        Console.WriteLine($"{myFraction.GetFractionString()}\n{myFraction.GetDecimalValue()}");

        myFraction.setNumerator(1);
        myFraction.setDenominator(3);

        Console.WriteLine($"{myFraction.GetFractionString()}\n{myFraction.GetDecimalValue()}");
    }
}