using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace FinalProject.Scenes
{
    class TitleScene : Scene
    {
        public TitleScene(Game game) : base(game)
        {
        }


        public override int Run()
        {
            string prompt = @"
    )                                              (                         
 ( /(                           (           (      )\ )       (   (          
 )\())  (   (  (     (          )\ )        )\ )  (()/(    (  )\  )\ )    )  
((_)\  ))\  )\))(   ))\  (     (()/(    (  (()/(   /(_))  ))\((_)(()/( ( /(  
 _((_)/((_)((_))\  /((_) )\ )   ((_))   )\  /(_)) (_))   /((_)_   ((_)))(_)) 
|_  /(_))   (()(_)(_))  _(_/(   _| |   ((_)(_) _| | |   (_)) | |  _| |((_)_  
 / / / -_) / _` | / -_)| ' \))/ _` |  / _ \ |  _| | |__ / -_)| |/ _` |/ _` | 
/___|\___| \__, | \___||_||_| \__,_|  \___/ |_|   |____|\___||_|\__,_|\__,_| 
           |___/                                                                                 
Use the arrow keys and press enter to make your choice.";
            string[] options = { "Start Game", "Exit" };
            Menu mainMenu = new Menu(options, prompt);

            int selection = mainMenu.Run();
            //string[] options = {options}
            //int selectedIndex;
            return selection;
        }

    }
}
