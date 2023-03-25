using System;
using System.Collections.Generic;
using System.Text;

using FinalProject.Characters;


namespace FinalProject.Scenes
{
    class Scene
    {
        protected Game _myGame;
        public Scene(Game game)
        {
            _myGame = game;
        }

        public virtual int Run()
        {
            return 0;
        }

        public virtual int Run(Character player, Character monster, string message)
        {
            return 0;
        }
    }
}