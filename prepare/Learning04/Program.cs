using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment aye = new Assignment("dribbs Chutney", "pogosticks");
        MathAssignment math = new MathAssignment("Dribbs Chutney", "Fractions", "7.3", "8-19");
        WritingAssignment writing = new WritingAssignment("Dribbs Chutney", "European History", "The Causes of World War II by Mary Waters");

        Console.WriteLine(aye.GetSummery());

        string stuff1 = math.GetSummery();
        string utherStuff1 = math.GetHomeworkList();
        Console.WriteLine($"{stuff1}\n{utherStuff1}");

        string stuff2 = writing.GetSummery();
        string utherStuff2 = writing.GerWritingInformation();
        Console.WriteLine($"{stuff2}\n{utherStuff2}");
    }
}


// Dribbs Chutney and the Pogosticks. LIVE IN CONCERT!