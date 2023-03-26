using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using FinalProject.Scenes;
using FinalProject.Characters;

class Game
{

    private TitleScene _titleScene;
    private CharacterScene _characterScene;
    private CombatScene _combatScene;
    private EndingScene _endingScene;
    public Game()
    {
        _titleScene = new TitleScene(this);
        _characterScene = new CharacterScene(this);
        _combatScene = new CombatScene(this);
        _endingScene = new EndingScene(this);
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
        Character mainCharacter;
        Character monster;
        string message;
        int aftermath;
        int charSelection = _characterScene.Run();
        switch (charSelection)
        {
            case 0:
                {
                    mainCharacter = new Hylian("Hylian", 5, 4, (float)0.5, (float)0.5);
                    message = "Time to begin a glorious journey. You are Clink: the self-proclaimed person who will probably do something cool at some point.\nDue to your passive-aggressive methods of borrowing money you have been unanimously voted by the village to take care of the monsters that have been harassing the nearby fishing pond — After all, that pond is very important for tourism. So off you go to fullfill your obligat- I mean destiny!\n";
                    break;

                }
            case 1:
                {
                    mainCharacter = new Sheikah("Sheikah", 3, 10, (float)0.75, (float)0.25);
                    message = "You are mysterious Sheet. You appeared one day mysteriously to protect this village, however aside from an overbearing passive-aggressive begger there is not much going on. However you were just informed via eavesdropping that there are some monsters appearing near the sacred mini lake nearby. Finally a chance to defend the defenseless! You immediately head out to save the world!\n";
                    break;
                }
            default:
                {
                    mainCharacter = new Skeleton("Skeleton", 4, 4, (float)0.75, (float)0.75);
                    message = "You broke the game before you even started it, so you are a skeleton now. I hope you're happy!\n";
                    break;
                }

        }
        // introduction and character selection
        Clear();
        WriteLine($"{message}");
        ConsoleUtilities.WaitForKeyPress();

        monster = new Scrub("Scrub", 2, 0, (float)0.5, (float)0.25);
        if (mainCharacter.GetName() == "Hylian")
        {
            message = "As the pond comes in to view you find that you have encounterd a Scrub! What is a scrub? it's a plant monster that kind of looks cute until it spits giant nuts at you. Then it just looks stupid. Kill it before it harasses you!\n";
        }
        else
        {
            message = "You see the sacred mini lake come into view and begin to slow your pace. moments later you hear a \"PFFFT\"! You turn quickly and manage to cleanly dodge the seed of a Scrub - the plant like monsters that live around here. You ready yourself to begin the task of saving the world.";
        }


        for (int i = 0; i < 3; i++)
        {
            aftermath = _combatScene.Run(mainCharacter, monster, message);
            if (aftermath == 0)
            {
                ExitGame();
            }
            if (mainCharacter.GetName() == "Hylian" && mainCharacter.GetSpecialTrait() == true && i != 3)
            {
                mainCharacter.SetSpecialTrait(false);
            }
            if (i == 0)
            {
                monster = new Poe("Poe", 3, 10, (float)0.5, (float)0.25);
                if (mainCharacter.GetName() == "Hylian")
                {
                    message = "You get near to the pond and hear an annoying laugh as a ghost known as a poe materializes near you. Oh Poe! It's not poetic, it's trying to kill you!\nYou should poe-lightly decline poe-rish-ing (perishing... that might have been too much of a streach. Oh well). Live up to your full poe-tential and kill it quick!\n";
                }
                else
                {
                    message = "You approach the sacred mini lake mesmerized by it's majestic nature. Your revere is cut short as you hear an evil laughter. Quickly sifting through your knowledge you recognize it to be the battle cry of the fearsome ghost type monster known as a poe! You know you must best this evil beast if you hope to continue your quest to save the world!\n";
                }
            }
            else if (i == 1)
            {

                monster = new Skeleton("Skeleton", 5, 4, (float)0.5, (float)0.5);
                if (mainCharacter.GetName() == "Hylian")
                {
                    message = "As you make your way around the pond you see a person up ahead clad for battle. You cautiously come closer when they turn towards you. You barely manage to suppress a pathetic sounding screem as you realize this WAS a person... as some point in the past. The skeleton begins moving towards you. Despite the lack of facial expression you can see a clear intent to kill.\n";
                }
                else
                {
                    message = "You continue your journey around the sacred mini lake thanking the Goddesses you have been bless to tread on such sacred ground. Suddenly a chill runs through your body.You freeze as you feel an icy gaze upon you. You quickly turn towards the direction of the sensation and skillfully evade a devastating attack. You gaze at the desecrated form of a once proud warrior and resolve yourself to give the skeleton the honor of being able to rest again.\n";
                }
            }
        }
        _endingScene.Run(mainCharacter);
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