// Class: Resume
// Responsibilities:
// Keeps track of the person's name and a list of their jobs.
// Behaviors:
// Displays the resume, which shows the name first, followed by displaying each one of the jobs.


public class Resume
{
    // attribute declaration
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // method declaration
    public Resume() { }

    public void Display()
    {
        Console.WriteLine(_name);
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}