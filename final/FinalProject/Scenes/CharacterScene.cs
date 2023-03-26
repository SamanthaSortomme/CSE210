using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace FinalProject.Scenes
{
    class CharacterScene : Scene
    {

        public CharacterScene(Game game) : base(game)
        {
        }


        public override int Run()
        {
            string prompt = @"
  Hylian - Warrior        Shiekah - Combat mage     

      ~?J!                     !??!.
     .~JY^                 .^~7??JY?:.
   :^~~7?~:                .:. ~77?75Y?~. 
:^~JJ?!!!??.                   ^JJYG5~?JY?:.::.
!7??77?~77?!                  ..!?7PP^   ^^!!:.
^!!7777!??^~^             .7JY5BBJJP777:   
.^!77!!!~7^:77:           .5#G???7~~7J55~  
  :^.^Y:^J ..?J.            Y&~      :7?555P7. 
    .!7 ~7.   7Y^        .:~BG.       .:^7YPPY7.
    :!~ :!:    ~5!       .^7?7!:             :7PP7 
    ^?: :^~^.   :?7.                           ~!!.
          
          Select your character";

            string[] options = { "Hylian", "Shiekah" };
            Menu CharacterMenu = new Menu(options, prompt);

            int selection = CharacterMenu.Run();
            return selection;
        }
    }
}