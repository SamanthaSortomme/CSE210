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

        public override int Run(Character player, Character monster, string message1)
        {

            // float playerCombatValue, monsterCombatValue;
            string[] options = CreateOptions(player.GetName());
            string prompt;
            string message2 = "Choose your choice to decide the decision. Or in other words, act the action.\n";
            while (true)
            {
                prompt = CreatePrompt(player, message1, message2);
                Menu attackMenu = new Menu(options, prompt);
                int playerChoice = attackMenu.Run();
                int monsterChoice = monster.MonsterChoice();

                message1 = ResolveAction(player, monster, playerChoice, monsterChoice);

                if (player.GetHeart() <= 0)
                {
                    message2 = "You have lost the fight and your life.";
                    prompt = CreatePrompt(player, message1, message2);
                    Clear();
                    WriteLine(prompt);
                    ConsoleUtilities.WaitForKeyPress();
                    return 0; // 0 indicates the player lost the battle
                }
                else if (monster.GetHeart() <= 0)
                {
                    message2 = "The hard fought victory is yours!";
                    prompt = CreatePrompt(player, message1, message2);
                    Clear();
                    WriteLine(prompt);
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

        private string CreatePrompt(Character player, string message1, string message2)
        {
            string heartGraphic = HeartGenerator(player.GetHeart());
            int magic = player.GetMagic();
            float attack = player.GetAttack();
            float defense = player.GetDefense();
            string prompt = $@"
{message1}

PLAYER STATS:
{heartGraphic}
ATTACK:  {attack}
DEFENSE: {defense}
MAGIC:   {magic}

{message2}";
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
            return heartStings;
        }

        // removed , float playerCV, float monsterCV from method
        private string ResolveAction(Character player, Character monster, int playerChoice, int monsterChoice)
        {
            string narrative = "";
            float pTotalDefense = player.GetDefense(); // set this way so we don't have to worry about finding the defense later if the player is not defending
            float mTotalDefense = monster.GetDefense();
            bool mActionComplete = false;
            bool mBlocking = false;
            bool mDead = false;
            // bool pDead = false; // not used
            string mName = monster.GetName();

            if (mName == "Skeleton" && monsterChoice == 1)
            {
                mTotalDefense = monster.DefenseSkill();
                narrative = $"{mName} quickly defends.\n";
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
                            mDead = DealDamage(monster, player, (player.AttackSkill() - mTotalDefense), ref narrative, false);
                        }
                        else
                        {
                            if (mName == "Scrub")
                            {
                                narrative += "You attempt to attack but the scrub is hiding in the ground and seems impossible to hit.\n";
                            }
                            else if (mName == "Poe")
                            {
                                narrative += "you strike at the poe but miss as it has completely gone invisible\n";
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        pTotalDefense = player.DefenseSkill();
                        narrative += player.DefendNarrative();
                        break;
                    }
                case 2:
                    {
                        if (!mBlocking)
                        {
                            mDead = DealDamage(monster, player, (player.SpecialSkill() - monster.GetDefense()), ref narrative, true);
                        }
                        else
                        {
                            if (mName == "Scrub")
                            {
                                narrative += "You attack with all your power but the scrub seems to be immune to all damage while hiding.\n";
                            }
                            else if (mName == "Poe")
                            {
                                narrative += "You unleash your most powerful attack only to find that an invisible poe can not be harmed.\n";
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        narrative += player.HealSkill();
                        break;
                    }
            }
            if (mDead)
            {
                return narrative;
            }

            if (!mActionComplete)
            {
                switch (monsterChoice)
                {
                    case 0:
                        {

                            DealDamage(player, monster, (monster.AttackSkill() - pTotalDefense), ref narrative, false);
                            break;
                        }
                    case 1:
                        {
                            monster.DefenseSkill();
                            narrative += monster.DefendNarrative();
                            break;
                        }
                    case 2:
                        {
                            DealDamage(player, monster, (monster.SpecialSkill() - pTotalDefense), ref narrative, true);
                            break;
                        }
                    // there is no active monster heal skill implemented at this time
                    // case 3 is used for special cases (warmup and cooldown for special skills)
                    case 3:
                        {
                            float setValue;
                            if (mName == "Poe")
                            {
                                setValue = monster.SpecialSkill();
                            }
                            else
                            {
                                monster.SetSpecialTrait(false);
                                setValue = 1;
                            }
                            narrative += monster.SpecialNarrative(setValue);

                            break;
                        }
                }
            }
            return narrative;
        }

        private bool DealDamage(Character receiver, Character dealer, float damage, ref string narrative, bool special)
        // returns true if damage is fatal damage is dealt, otherwise returns false.
        {
            if (damage > 0)
            {
                string name = receiver.GetName();
                float health = receiver.GetHeart() - damage; ;
                bool died;
                receiver.SetHeart(health);
                if (special)
                {
                    narrative += dealer.SpecialNarrative(damage);
                }
                else
                {
                    narrative += dealer.AttackNarrative(damage);
                }

                if (health <= 0)
                {
                    died = true;

                    if (name == "Hylian" || name == "Scrub")
                    {
                        narrative += receiver.HealSkill();
                        if (receiver.GetHeart() > 0)
                        {
                            died = false;
                        }
                    }
                }
                else
                {
                    died = false;
                }
                return died;
            }
            else
            {
                if (special)
                {
                    narrative += dealer.SpecialNarrative(0);
                }
                else
                {
                    if (dealer.GetName() == "Hylian" || dealer.GetName() == "Shiekah")
                    {
                        narrative += $"Your attack is deflected dealing no damage.\n";
                    }
                    else
                    {
                        narrative += $"You successfully defend yourself from the monsters attack and take no damage. \n";
                    }
                }
                return false;
            }
        }

    }
}


