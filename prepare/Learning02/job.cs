// Class: Job
// Responsibilities:
// Keeps track of the company, job title, start year, and end year.
// Behaviors:
// Displays the job information in the format

public class Job
{
    // attribute declaration
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // method declaration
    public Job()
    {
    }
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}