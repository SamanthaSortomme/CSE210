using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using FinalProject.Scenes;
using FinalProject.Characters;

class Game
{

    public TitleScene _titleScene;
    public CombatScene _combat;
    public Game()
    {
        _titleScene = new TitleScene(this);
        _combat = new CombatScene(this);
    }
    public void Start()
    {

        int selection = _titleScene.Run();
        switch (selection)
        {
            case 0:
                {
                    StartGame();
                    break;
                }
            case 1:
                {
                    break;
                }
            case 2:
                {
                    ExitGame();
                    break;
                }
        }


    }

    private void StartGame()
    {
        // introduction and character selection
        WriteLine("Time to begin a glorious journey. you are Clink. the self-proclaimed person who might do something cool at some point. due to your passive-aggressive methods of borrowing money you have been unanamously voted by the village to take care of the monsters that have been harrassing the nearby fishing pond. After all, that pond is very important for tourism.");
        ConsoleUtilities.WaitForKeyPress();
        Hylian clink = new Hylian("Hylian", 5, 4, (float)0.5, (float)0.5);
        Scrub deku = new Scrub("Scrub", 2, 0, (float)0.5, (float)0.25);

        // string message = "You have encounterd a Scrub! What is a scrub? it's a plant monster that kind of looks cute until it spits seeds at you. Then it just looks stupid. Kill it before it harasses you!";

        Skeleton bones = new Skeleton("Skeleton", 5, 4, (float)0.5, (float)0.5);
        string message = "You see a person up ahead clad for battle, as you cautiously come closer they turn towards you. You barely manage to suppress a screem as you realize this WAS a person... as some point in the past. The skeleton begins moving towards you. despite the lack of facial expression you can see a clear intent to kill.";


        _combat.Run(clink, bones, message);


    }



    private void ExitGame()
    {

        Environment.Exit(0);
    }

    //Scene
    //Title Screen
    //Fight
    //
}