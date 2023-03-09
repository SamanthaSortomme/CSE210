class Word
{

    private string _word;
    private bool _vis;
    private string _hidden;


    public Word() { }
    public Word(string word, bool vis = true)
    {
        _word = word;
        _vis = vis;
        SetHidden();
    }

    public void SetHidden()
    {
        int wordLength = _word.Length;
        _hidden = "";
        for (int i = 0; i < wordLength; i++)
        {
            _hidden += "_";
        }
    }

    public void SetWord(string word)
    {
        _word = word;
    }

    public void SetVis(bool vis)
    {
        _vis = vis;
    }

    public string GetWord()
    {
        return _word;
    }

    public bool GetVis()
    {
        return _vis;
    }

    public string GetHidden()
    {
        return _hidden;
    }

    public void PrintWord()
    {
        Console.Write($"{_word} ");
    }

    public void PrintHidden()
    {
        Console.Write($"{_hidden} ");
    }








}