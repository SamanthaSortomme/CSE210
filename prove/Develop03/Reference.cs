class Reference
{

    private string _book;
    private string _chapter;
    private string _startVerse;
    private string _endVerse;

    public Reference() { }

    public Reference(string book, string chapter, string startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
    }

    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetBook()
    {
        return _book;
    }

    public string GetChapter()
    {
        return _chapter;
    }

    public string GetStartVerse()
    {
        return _startVerse;
    }

    public string GetEndVerse()
    {
        return _endVerse;
    }

    public void SetBook(string book)
    {
        _book = book;
    }

    public void SetChapter(string chapter)
    {
        _chapter = chapter;
    }

    public void SetStartVerse(string verse)
    {
        _startVerse = verse;
    }

    public void SetEndVerse(string verse)
    {
        _endVerse = verse;
    }

    public string GetReference()
    {
        if (String.IsNullOrEmpty(_endVerse))
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }

    public void PrintReference()
    {
        if (String.IsNullOrEmpty(_endVerse))
        {
            Console.Write($"{_book} {_chapter}:{_startVerse}  ");
        }
        else
        {
            Console.Write($"{_book} {_chapter}:{_startVerse}-{_endVerse}  ");
        }
    }

}