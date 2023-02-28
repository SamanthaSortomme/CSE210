public class Entry
{
    // attribute declaration
    public string _date;
    public string _prompt;
    public string _response;


    // method delcaration
    public Entry() { }

    public void GetTime()
    {
        DateTime theCurrentTime = DateTime.Now;
        _date = theCurrentTime.ToShortDateString();
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}\n{_response}");

    }
}