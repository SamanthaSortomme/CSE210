namespace FinalProject.Characters
{
    public class Skeleton : Character
    {
        public Skeleton(string _name, float heart, int magic, float attack, float defense) : base(_name, heart, magic, attack, defense)
        {
        }

        public override string AttackNarrative(float damage)
        {
            return $"The Skeleton takes its sword and slashes you. You take {damage} hearts worth of damage.\n";
        }

        public override float AttackSkill()
        {
            float min = (float)0.25;
            float max = (float)0.75;
            float attack = GenerateValue(min, max) + GetAttack();// return number between min and max
            return attack;
        }

        public override string DefendNarrative()
        {
            return $"The Skeleton quickly and skillfuly readies its shield.\n";
        }

        public override float DefenseSkill()
        {
            return GetDefense() * 3;
        }

        public override string HealNarrative()
        {
            return $"The Skeleton laughs, then his ribcage pops back into place.\n";
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
                float defend = (float)0.80;
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
            if (GetSpecialTrait())
            {
                return $"Without warning the skeleton leaps forward with a mighy downward strike. You take {damage} hearts worth of damage but it looks like it will take a moment for the skeleton to regain its composure.\n";

            }
            else
            {
                if (damage == 1)
                {
                    return $"The skeleton recovers from its attack.\n";
                }
                else
                {
                    return $"The skeleton tries to launch its suprise attack, but without the aid of its magical power the motion is easily avioded.\n";
                }
            }
        }

        public override float SpecialSkill()
        {
            int magic = GetMagic();
            if (magic >= 2)
            {
                magic -= 2;
                SetMagic(magic);
                SetSpecialTrait(true);
                float attack = (float)1.5 + GetAttack();
                return attack;
            }
            else
            {
                return 0;
            }
        }

    }
}