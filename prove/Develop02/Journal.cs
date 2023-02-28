using System.IO;

public class Journal
{

    // attribute declaration
    public List<Entry> _entries = new List<Entry>();

    // method declaration
    public Journal() { }


    public void Display()
    {
        if (_entries.Count != 0)
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
        else
        {
            Console.WriteLine("There are no entries in this journal.\n");
        }
    }

    public void Write(string question)
    {
        Entry entry = new Entry();
        entry._prompt = question;
        Console.Write($"{entry._prompt}\n>");
        entry._response = Console.ReadLine();
        entry.GetTime();
        _entries.Add(entry);
    }

    // promps user for text file name and saves current journal to that file
    public void Save()
    {
        string fileName;
        Console.Write("Enter the file name: ");
        fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
                // You can add text to the file with the WriteLine method
                outputFile.WriteLine($"{entry._date}~{entry._prompt}~{entry._response}~");
        }
    }

    public void Load()
    {
        string fileName;
        Console.Write("Enter the file name: ");
        fileName = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(fileName);
        int entryCount = 0;
        foreach (string line in lines)
        {
            _entries.Add(new Entry());
            string[] parts = line.Split("~");
            _entries[entryCount]._date = parts[0];
            _entries[entryCount]._prompt = parts[1];
            _entries[entryCount]._response = parts[2];
            entryCount++;
        }
    }
}