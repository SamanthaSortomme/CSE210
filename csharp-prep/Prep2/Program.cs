using System;

class Program
{
    static void Main(string[] args)
    {
        float gradeNum;
        string gradeLet;
        Console.Write("What is your grade percentage? ");
        gradeNum = float.Parse(Console.ReadLine());

        if (gradeNum >= 90)
        {
            if (gradeNum >= 93)
            {
                gradeLet = "A";
            }
            else
            {
                gradeLet = "-A";
            }
        }

        else if (gradeNum >= 80)
        {
            if (gradeNum >= 87)
            {
                gradeLet = "+B";
            }
            else if (gradeNum >= 83)
            {
                gradeLet = "B";
            }
            else
            {
                gradeLet = "-B";
            }
        }

        else if (gradeNum >= 70)
        {
            if (gradeNum >= 77)
            {
                gradeLet = "+C";
            }
            else if (gradeNum >= 73)
            {
                gradeLet = "C";
            }
            else
            {
                gradeLet = "-C";
            }
        }

        else if (gradeNum >= 60)
        {
            if (gradeNum >= 67)
            {
                gradeLet = "+D";
            }
            else if (gradeNum >= 63)
            {
                gradeLet = "D";
            }
            else
            {
                gradeLet = "-D";
            }
        }

        else
        {
            gradeLet = "F";
        }

        if (gradeNum >= 70)
        {
            Console.WriteLine($"You have passed this course with a {gradeLet}. Congrats!");
        }
        else
        {
            Console.WriteLine($"You got a {gradeLet}. You did not pass the class. Study harder next time.");
        }

    }
}