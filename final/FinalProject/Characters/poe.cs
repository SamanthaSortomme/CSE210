namespace FinalProject.Characters
{
    public class Poe : Character
    {
        public Poe(string _name, float heart, int magic, float attack, float defense) : base(_name, heart, magic, attack, defense)
        {
        }

        public override string AttackNarrative(float damage)
        {
            return $"It runs into you, you feel sick to your stomach. You take {damage} hearts worth of damage.\n";
        }

        public override float AttackSkill()
        {
            return (float)0.25 + GetAttack();
        }

        public override string DefendNarrative()
        {
            return $"With a irritating laugh the poe's body suddenly becomes transparent till it is almost completely invisible.\n";
        }

        public override float DefenseSkill()
        {
            SetBlocking(true);
            return 0;
        }

        public override string HealNarrative()
        {
            return $"It seems to glow a little bit more, can the dead be brought back to life?";
        }

        public override string HealSkill()
        {
            throw new NotImplementedException();
        }

        public override int MonsterChoice()
        {
            if (!GetSpecialTrait())
            {
                // 50% chance to attack
                // 35% chance to defend
                // 15% chance to perform special
                float attack = (float)0.50;
                float defend = (float)0.85;
                float choice = GenerateValue(0, 1, false);
                if (choice < attack)
                {
                    return 0;
                }
                else if (choice < defend)
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return 2;
            }

        }

        public override string SpecialNarrative(float damage)
        {
            if (GetSpecialTrait())

            {
                return "The Poe begins spinning around in circles.\n";
            }
            else
            {
                if (damage > 0)
                {
                    return $"Now it's spinning faster and moves quickly towards you. AHHHHH!!! You take {damage} hearts worth of damage.\n";
                }
                else
                {
                    return $"The poe attempts to spin, but without magical energy it cannot gain any momentum and gives up on the attack.\n";
                }
            }
        }

        public override float SpecialSkill()
        {
            if (!GetSpecialTrait())
            {
                int magic = GetMagic();
                if (magic >= 5)
                {
                    magic -= 5;
                    SetMagic(magic);
                    SetSpecialTrait(true);
                    return 0;
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                SetSpecialTrait(false);
                return ((float)0.25 + GetAttack()) * 4;
            }
        }

    }
}