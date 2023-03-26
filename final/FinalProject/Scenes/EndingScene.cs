using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

using FinalProject.Characters;


namespace FinalProject.Scenes
{
    class EndingScene : Scene
    {
        public EndingScene(Game game) : base(game)
        {
        }


        public override void Run(Character player)
        {
            string message;
            string theEnd = @"_________          _______    _______  _        ______  
\__   __/|\     /|(  ____ \  (  ____ \( (    /|(  __  \ 
   ) (   | )   ( || (    \/  | (    \/|  \  ( || (  \  )
   | |   | (___) || (__      | (__    |   \ | || |   ) |
   | |   |  ___  ||  __)     |  __)   | (\ \) || |   | |
   | |   | (   ) || (        | (      | | \   || |   ) |
   | |   | )   ( || (____/\  | (____/\| )  \  || (__/  )
   )_(   |/     \|(_______/  (_______/|/    )_)(______/ 
                                                       ";

            if (player.GetName() == "Hylian")
            {
                message = $"You have cleared the area around the pond as you have been required too. Now you can go fishing! Except you hate fishing more than you do returning money that you borrowed. Why don't you take a nap and enjoy your victory?\n\n";
            }
            else
            {
                message = $"At last, peace returns to the sacred mini lake. you gaze up into the sky as you let the sunlight bath what little of your skin is exposed. You know that your deeds will be recorded in the annuls of history, but what matters is that you have proven your worth. You remove your head covering to reveal to the sacred mini lake that you are in fact the princess Lelda. You smile, greatful for this wonderous adventure.\n\n";
            }
            Console.Clear();
            Write($"{message}{theEnd}");
        }


    }
}