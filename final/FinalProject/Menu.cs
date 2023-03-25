using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class Menu
{
    private int _selectedIndex;
    private string[] _options;
    private string _prompt;

    public Menu(string[] options, string prompt)
    {
        _selectedIndex = 0;
        _options = options;
        _prompt = prompt;
    }

    private void DisplayOptions()
    {
        WriteLine(_prompt);
        for (int i = 0; i < _options.Length; i++)
        {
            string currentOption = _options[i];
            if (i == _selectedIndex)
            {
                WriteLine($"<< {currentOption} >>");
            }
            else
            {
                WriteLine($"   {currentOption}");
            }
        }
    }
    public int Run()
    {

        ConsoleKey keyPressed;
        do
        {
            Clear();
            DisplayOptions();

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.UpArrow && _selectedIndex != 0)
            {
                _selectedIndex--;
            }
            else if (keyPressed == ConsoleKey.DownArrow && _selectedIndex != _options.Length - 1)
            {
                _selectedIndex++;
            }
        } while (keyPressed != ConsoleKey.Enter);

        return _selectedIndex;
    }
}