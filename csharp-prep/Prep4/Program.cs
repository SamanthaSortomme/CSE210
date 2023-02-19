using System;

class Program
{
    static void Main(string[] args)
    {
        int number;
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of number, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);
        int sum = 0;
        float average;
        int largest = 0;
        int smallestPositive = 9999999;

        numbers.Sort();
        foreach (int num in numbers)
        {
            sum += num;
            if (num > largest)
            {
                largest = num;
            }
            if (num > 0 && num < smallestPositive)
            {
                smallestPositive = num;
            }
        }
        average = (float)sum / (float)numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine($"The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}