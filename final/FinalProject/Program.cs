using System;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Game myGame = new Game();
        myGame.Start();
    }
}