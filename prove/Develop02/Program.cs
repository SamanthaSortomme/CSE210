// 1 Write a new entry - Show the user a random prompt (from a list that you create), and save their response, the prompt, and the date as an Entry.
// 2 Display the journal - Iterate through all entries in the journal and display them to the screen.
// 3 Save the journal to a file - Prompt the user for a filename and then save the current journal (the complete list of entries) to that file location.
// 4 Load the journal from a file - Prompt the user for a filename and then load the journal (a complete list of entries) from that file. This should replace any entries currently stored the journal.
// 5 Provide a menu that allows the user choose these options
// 6 Your list of prompts must contain at least five different prompts. Make sure to add your own prompts to the list, but the following are examples to help get you started:

// In addition, your program must:

// 1 Contain classes for the major components in the program.
// 2 Contain at least two classes in addition to the Program class.
// 3 Demonstrate the principle of abstraction by using member variables and methods appropriately.

using System;


class Program
{
    static List<string> questions = new List<string>(new string[] {
        "how tall were you today?",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is love? (baby don't hurt me)",
        "what are you never gonna give up?",
        "What is the meaning of live the universe and everything?"
    });

    static void Main(string[] args)
    {
        Journal myJournal = new Journal();

        //test save functionality
        // myJournal._entries.Add(new Entry());
        // myJournal._entries[0]._date = "11/2/2022";
        // myJournal._entries[0]._prompt = "what is the squarer root of 2?";
        // myJournal._entries[0]._response = "how would I know that? I don't even know what I ate for dinner last night.";

        // myJournal.Save();
        //test load functionality
        //myJournal.Load();

        myJournal.Display();

        // myJournal.Write("Write something.");
        // myJournal.Write("Write something mark2.");
        // myJournal.Write("Write something the third.");
        // myJournal.Display();

        int number;
        //        Console.Write(number);

        while (true)
        {
            number = GetChoice();
            if (number != 5)
            {
                Execute(number, myJournal);
            }
            else
            {
                break;
            }
        }

    }

    static int GetChoice()
    {
        while (true)
        {
            Console.Write("Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\nWhat would you like to do? ");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice > 0 && choice < 6)
                {
                    return choice;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }

    static void Execute(int choice, Journal myJournal)
    {
        switch (choice)
        {
            case 1:
                string question = getQuestion();
                myJournal.Write(question);
                break;

            case 2:
                myJournal.Display();
                break;

            case 3:
                myJournal.Load();
                break;

            case 4:
                myJournal.Save();
                break;

            default:
                break;
        }
    }

    static string getQuestion()
    {
        var rand = new Random();
        int index = rand.Next(questions.Count);
        string question = questions[index];
        return question;
    }
}


//  static void HomeDisplay(){
//     Console.WriteLine("welcome");
//     Console.WriteLine("seclect a choice");
//     Console.WriteLine("1 write");
//     Console.WriteLine("2 display");
//     Console.WriteLine("3 load");
//     Console.WriteLine("4 save");
//     Console.WriteLine("5 quit");
//  }
//  HomeDisplay();
//  Console.WriteLine("option 1 will exicute now.");
//  Journal newJournal = new Journal();
//  newJournal.AddEntry();
//  Console,WriteLine("option 2 will exicute now")