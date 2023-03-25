using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using FinalProject.Characters;

namespace FinalProject.Scenes
{
    class CombatScene : Scene
    {
        public CombatScene(Game game) : base(game)
        {
        }

        public override int Run(Character player, Character monster, string message)
        {

            // used to reference whether the character is attacking, defending, or healing to determine how the combat value is used.
            // byte playerActionReference = 0;
            // byte monsterActionReference = 0;

            // float playerCombatValue, monsterCombatValue;
            string[] options = CreateOptions(player.GetName());
            while (true)
            {
                string prompt = CreatePrompt(player, message);
                Menu attackMenu = new Menu(options, prompt);
                int playerChoice = attackMenu.Run();
                int monsterChoice = monster.MonsterChoice();

                // playerCombatValue = CharacterAction(player, choice, ref playerActionReference);

                // monsterCombatValue = CharacterAction(monster, monsterChoice, ref monsterActionReference);
                // removed playerCombatValue, monsterCombatValue, from resolveAction
                message = ResolveAction(player, monster, playerChoice, monsterChoice);

                if (player.GetHeart() <= 0)
                {
                    WriteLine("You have lost.");
                    ConsoleUtilities.WaitForKeyPress();
                    return 0; // 0 indicates the player lost the battle
                }
                else if (monster.GetHeart() <= 0)
                {
                    WriteLine("You have won!");
                    ConsoleUtilities.WaitForKeyPress();
                    return 1; // 1 indicates the player won the battle
                }
            }
        }


        private string[] CreateOptions(string name)
        {
            string[] options;
            if (name == "Hylian")
            {
                string[] temp = { "Slash - basic attack", "Shield - block 2x defense damage and restores 2MP", "Spin Attack (2MP) - deals two basic attacks" };
                options = temp;
            }
            else
            {
                string[] temp = { "Strike -basic attack", "Block - blocks 2 x defense damage and restores 2MP", "Dimm's Fire (4MP) - deal significant damage", "Heal (2PM) = restore 75% of total hearts " };
                options = temp;
            }

            return options;
        }

        private string CreatePrompt(Character player, string message)
        {
            string heartGraphic = HeartGenerator(player.GetHeart());
            int magic = player.GetMagic();
            float attack = player.GetAttack();
            float defense = player.GetDefense();
            string prompt = $@"
{message}

PLAYER STATS:
{heartGraphic}ATTACK:  {attack}
DEFENCE: {defense}
MAGIC:   {magic}

Choose your choice to decide the decision. Or in other words, act the action.
";
            return prompt;
        }

        private string HeartGenerator(float hearts)
        {
            // will generate a string of heart symboles like below
            // (`')(`')(`')(`')(`')
            //  \/  \/  \/  \/  \/
            //three quarter heart
            // (`
            //  \/ 
            //half heart
            // (`
            //  \ 
            //quarter heart
            // (`
            //  

            string heartStings = "";
            int totalHearts = (int)(hearts * 4);
            int fullHearts = totalHearts / 4;
            int partialHeart = totalHearts % 4;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < fullHearts; j++)
                {
                    if (i == 0)
                    {
                        heartStings += "(`')";
                    }
                    else
                    {
                        heartStings += " \\/ ";
                    }
                }
                if (partialHeart > 0)
                {
                    if (i == 0)
                    {
                        heartStings += $"(`\n";
                    }
                    else
                    {
                        if (partialHeart == 2)
                        {
                            heartStings += " \\";
                        }
                        else if (partialHeart == 3)
                        {
                            heartStings += " \\/";
                        }
                    }
                }
                else
                {
                    heartStings += $"\n";
                }

            }
            heartStings += $"\n";
            return heartStings;
        }


        // private float CharacterAction(Character character, int choice, ref byte actionReference)
        // {
        //     float combatValue = 0;
        //     switch (choice)
        //     {
        //         case 0:
        //             {
        //                 actionReference = 0;
        //                 combatValue = character.AttackSkill();
        //                 break;
        //             }
        //         case 1:
        //             {
        //                 actionReference = 1;
        //                 combatValue = character.DefenseSkill();
        //                 break;
        //             }
        //         case 2:
        //             {
        //                 actionReference = 2;
        //                 combatValue = character.SpecialSkill();
        //                 break;
        //             }
        //         case 3:
        //             {
        //                 actionReference = 3;
        //                 combatValue = 0;
        //                 break;
        //             }
        //     }
        //     return combatValue;

        // }

        // removed , float playerCV, float monsterCV from method
        private string ResolveAction(Character player, Character monster, int playerChoice, int monsterChoice)
        {
            string narrative = "";
            float pTotalDefense = player.GetDefense(); // set this way so we don't have to worry about finding the defense later if the player is not defending
            float mTotalDefense = monster.GetDefense();
            bool mActionComplete = false;
            bool mBlocking = false;
            bool mDead = false;
            bool pDead = false;
            string mName = monster.GetName();

            if (mName == "Skeleton" && monsterChoice == 2)
            {
                mTotalDefense = monster.DefenseSkill();
                narrative = $"{mName} quickly defends.";
                mActionComplete = true;
            }
            else if ((mName == "Scrub" || mName == "Poe") && monster.GetBlocking())
            {
                mBlocking = true;
                monster.SetBlocking(false);
            }

            switch (playerChoice)
            {
                case 0:
                    {
                        if (!mBlocking)
                        {
                            mDead = DealDamage(monster, (player.AttackSkill() - mTotalDefense), ref narrative);
                        }
                        break;
                    }
                case 1:
                    {
                        pTotalDefense = player.DefenseSkill();
                        break;
                    }
                case 2:
                    {
                        if (!mBlocking)
                        {
                            mDead = DealDamage(monster, (player.SpecialSkill() - monster.GetDefense()), ref narrative);
                        }
                        break;
                    }
                case 3:
                    {
                        player.HealSkill();
                        break;
                    }
            }
            if (mDead)
            {
                return "You have succeeded in not losing!\n";
            }

            if (!mActionComplete)
            {
                switch (monsterChoice)
                {
                    case 0:
                        {

                            pDead = DealDamage(player, (monster.AttackSkill() - pTotalDefense), ref narrative);
                            break;
                        }
                    case 1:
                        {
                            monster.DefenseSkill();
                            break;
                        }
                    case 2:
                        {
                            pDead = DealDamage(player, (monster.AttackSkill() - pTotalDefense), ref narrative);
                            break;
                        }
                        // there is no active monster heal skill implemented at this
                        // case 4:
                        //     {
                        //         break;
                        //     }
                }
            }
            return narrative;
        }

        private bool DealDamage(Character character, float damage, ref string narrative)
        // returns true if damage is fatal damage is dealt, otherwise returns false.
        {
            if (damage > 0)
            {
                string name = character.GetName();
                float actualDamage = character.GetHeart() - damage;
                float health = actualDamage;
                character.SetHeart(health);
                if (health <= 0)
                {
                    if (name == "Hylian" || name == "Scrub")
                    {
                        narrative += character.HealSkill();
                        if (health <= 0)
                        {
                            return true;
                        }
                    }
                    return true;
                }
                if (name == "Hylian" || name == "Sheikah")
                {
                    narrative += $"You are hit for {damage} hearts worth of damage.";
                }
                else
                {
                    narrative += $"You attack and deal {damage} hearts worth of damage.";
                }
                return false;
            }
            return false;
        }

    }
}


