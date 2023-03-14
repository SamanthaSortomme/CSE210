internal class WritingAssignment : Assignment
{
    string _title;

    public WritingAssignment()
    {
    }

    public WritingAssignment(string title)
    {
        _title = title;
    }

    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }

    public string GerWritingInformation()
    {
        return _title;
    }
}