using System;
using System.Text.RegularExpressions;
class Program
{

    static void Main(string[] args)
    {
        // KeyValuePair<string, string> reference = new KeyValuePair<string, string>("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        // Scripture scripture = new Scripture();

        // scripture = LoadScripture(reference, false);

        // bool stop = false;
        // while (!stop)
        // {
        //     DisplayReading(scripture);
        //     Console.ReadLine();
        //     stop = scripture.ChangeWords(false);

        // }
        // DisplayReading(scripture);
        // Console.ReadLine();


        string dictionaryFile = "scripture.csv";

        Dictionary<string, string> scriptureBank = ReadFile(dictionaryFile);
        int intChoice;
        string sChoice;
        KeyValuePair<string, string> passage;
        Scripture scripture = new Scripture();
        bool finished = false;

        // foreach (KeyValuePair<string, string> entry in scriptureBank)
        // {
        //     Console.Write(entry.Key + entry.Value);
        // }


        while (true)
        {
            // what passage do you want to work on? [show list of reference]
            Console.Write($"What passages of scripture do you want to work on memorizing? (enter the number next to the passage you want)\n");
            int passageIndex = 0;

            foreach (KeyValuePair<string, string> entry in scriptureBank)
            {
                Console.Write($"{passageIndex} {entry.Key}\n");
                passageIndex++;
            }
            try
            {
                intChoice = int.Parse(Console.ReadLine());
                passage = scriptureBank.ElementAt(intChoice);
                break;
            }

            catch (FormatException e)
            {
                Console.WriteLine($"{e.Message} Please enter the number associated with the passage you want.\n");
            }

            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"{e.Message}. Please select a valid option.\n");
            }

        }

        // do you want to memorize or recite? [if memorize set bool memorize = true. else false]
        Console.Write($"would you like to memorize or recite the passage (m/r)?\n");
        sChoice = Console.ReadLine();
        bool memorize;
        if (sChoice.ToLower() == "m")
        {
            memorize = true;
        }
        else
        {
            memorize = false;
        }
        // load scripture with passage
        scripture = LoadScripture(passage, memorize);

        do
        {
            // clear console, display scripture
            DisplayReading(scripture);
            // prompt to press enter or type quit
            Console.Write($"\n\npress enter to continue or type quit to... quit. . .\n");

            sChoice = Console.ReadLine();
            if (sChoice == "quit")
            {
                finished = true;
            }
            else
            {
                finished = scripture.ChangeWords(memorize);
            }
        } while (!finished);

    }

    static void DisplayReading(Scripture passage)
    {
        Console.Clear();
        passage.PrintScripture();
    }

    static Dictionary<string, string> ReadFile(string fileName)
    {
        Dictionary<string, string> textDictionary = new Dictionary<string, string>();
        List<string> outputFile = File.ReadLines(fileName).ToList();

        foreach (string line in outputFile)
        {
            string[] result = Regex.Split(line, "[,]{1}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            result[1] = Regex.Replace(result[1], "\"", "");
            textDictionary.Add(result[0], result[1]);
        }

        return textDictionary;
    }

    static Scripture LoadScripture(KeyValuePair<string, string> passage, bool memorize)
    {
        Scripture scripture = new Scripture();

        scripture.SetReference(passage.Key);
        scripture.SetWords(passage.Value, memorize);

        return scripture;
    }



}

