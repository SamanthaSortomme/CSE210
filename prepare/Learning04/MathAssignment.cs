internal class MathAssignment : Assignment
{
    string _textbookSection;
    string _problems;
    public MathAssignment() { }

    public MathAssignment(string textbookSection, string problems)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public MathAssignment(string name, string topic, string textbookSection, string problems) : base(name, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
