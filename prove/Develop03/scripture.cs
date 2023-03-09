using System.Text.RegularExpressions;

class Scripture
{
    private Reference _reference = new Reference();
    private List<Word> _words = new List<Word>();


    public Scripture() { }

    public Scripture(string reference, string words)
    {
        SetReference(reference);
        SetWords(words, true);
    }

    public bool AllHidden()
    {
        bool isEmpty = true;
        foreach (Word word in _words)
        {
            if (word.GetVis())
            {
                isEmpty = false;
                break;
            }
        }
        return isEmpty;
    }

    public bool AllVisible()
    {
        bool isFull = true;
        foreach (Word word in _words)
        {
            if (!word.GetVis())
            {
                isFull = false;
                break;
            }
        }
        return isFull;
    }

    public string GetScriptureReference()
    {
        return _reference.GetReference();
    }

    public List<Word> GetWords()
    {
        return _words;
    }

    public void SetReference(string reference)
    {
        // Proverbs 3:5-6
        char[] delimitersChars = { ' ', ':', '-' };
        string[] items = reference.Split(delimitersChars);
        if (items.Length == 3)
        {
            _reference.SetBook(items[0]);
            _reference.SetChapter(items[1]);
            _reference.SetStartVerse(items[2]);
        }
        else if (items.Length == 4)
        {
            _reference.SetBook(items[0]);
            _reference.SetChapter(items[1]);
            _reference.SetStartVerse(items[2]);
            _reference.SetEndVerse(items[3]);
        }
        else
        {
            Console.Write("The reference string is not in the correct format to parse. Also, I don't like you.");
        }
    }

    public void SetWords(string words, bool memorize)
    {
        _words.Clear();
        string[] items = Regex.Split(words, @"\W"); // split string, removing all non-letters and put into array 
        items = items.Where(x => !string.IsNullOrEmpty(x)).ToArray();   // remove the empty array elements
        if (memorize)
        {
            foreach (string item in items)
            {
                Word word = new Word(item);
                _words.Add(word);
            }
        }
        else
        {
            foreach (string item in items)
            {
                Word word = new Word(item, false);
                _words.Add(word);
            }
        }
    }

    public bool ChangeWords(bool hideOrSee)
    {
        bool visibility;
        // check to see if all words are hidden or not. return true if they are
        if (hideOrSee)
        {
            visibility = AllHidden();
        }
        else
        {
            visibility = AllVisible();
        }
        if (!visibility)
        {
            var rand = new Random();
            int totalWords = _words.Count;
            int fifth = totalWords / 5;
            if (fifth < 1)
            {
                fifth = 2;
            }
            int toHide = rand.Next(1, fifth); // selects a random number of words to hide up to 1/5th of the total words

            //hide the alloted number of words semi-randomly. if a word is already hidden look through the words until an unhidden one is found.
            int i = 0;
            while (i < toHide)
            {
                int hideOfSeeWord = rand.Next(totalWords); //pick a random word to hide
                //check if the selected word is visible or not.
                //if visible, set to invisible.
                //if not visible, increment through the list of words. (cycle back to 0 if the end is reached)
                if (_words[hideOfSeeWord].GetVis() == hideOrSee)
                {
                    _words[hideOfSeeWord].SetVis(!hideOrSee);
                }
                else
                {
                    int nextWord;
                    if (hideOfSeeWord < totalWords - 1)
                    {
                        nextWord = hideOfSeeWord + 1;
                    }
                    else
                    {
                        nextWord = 0;
                    }
                    while (nextWord != hideOfSeeWord)
                    {
                        if (_words[nextWord].GetVis() == hideOrSee)
                        {
                            _words[nextWord].SetVis(!hideOrSee);
                            break;
                        }
                        else
                        {
                            if (nextWord < totalWords - 1)
                            {
                                nextWord++;
                            }
                            else
                            {
                                nextWord = 0;
                            }
                        }
                    }
                    if (nextWord == hideOfSeeWord) // this case will only happen if the while loop iterated through every word and found no visible words
                    {
                        break;
                    }
                }
                i++;
            }
            return visibility;
        }
        else
        {
            return visibility;
        }
    }



    public void PrintScripture()
    {
        _reference.PrintReference();
        foreach (Word word in _words)
        {
            if (word.GetVis())
            {
                word.PrintWord();
            }
            else
            {
                word.PrintHidden();
            }
        }
    }

}

