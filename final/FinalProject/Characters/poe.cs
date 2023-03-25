namespace FinalProject.Characters
{
    public class Poe : Character
    {
        public Poe(string _name, float heart, int magic, float attack, float defense) : base(_name, heart, magic, attack, defense)
        {
        }

        public override string AttackNarrative(float damage)
        {
            return $"It runs into you, you feel sick to your stomach, take {damage} hearts worth of damage.";
        }

        public override float AttackSkill()
        {
            return (float)0.25 + GetAttack();
        }

        public override string DefendNarrative()
        {
            return $"You try to hit it, but it goes invisible.";
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
                float attack = (float)0.50; // anything less than .35 and the monster will attack
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
                    return 2;
                }
            }
            else
            {
                return 3;
            }

        }

        public override string SpecialNarrative(float damage)
        {
            return $"It starts swirling, now it's spinning in circles and moving toward you. AHHHHH!!! You take {damage} hearts worth of damage.";
        }

        public override float SpecialSkill()
        {
            if (!GetSpecialTrait())
            {
                int magic = GetMagic();
                if (magic >= 6)
                {
                    magic -= 2;
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