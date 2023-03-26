namespace FinalProject.Characters
{
    public class Scrub : Character
    {
        public Scrub(string _name, float heart, int magic, float attack, float defense) : base(_name, heart, magic, attack, defense)
        {
        }

        public override string AttackNarrative(float damage)
        {
            return $"The scrub spits a large nut right at your face. {damage} hearts worth of damage knock the wind out of you.\n";
        }

        public override float AttackSkill()
        {
            return (float)0.25 + GetAttack();
        }

        public override string DefendNarrative()
        {
            return $"He plops in the ground looking like an overgrown weed.\n";
        }

        public override float DefenseSkill()
        {
            SetBlocking(true);
            return 0;
        }

        public override string HealNarrative()
        {
            if (GetHeart() <= 0)
            {
                return $"The Scrub gets knocked out of its hidey-hole and flounders for a moment before it stops moving.\n";
            }
            else
            {
                return "The Scrub gets knocked out of its hidey-hole and flounders for a moment before regaining its composure; quickly diving back in. You're not sure, but it seems its wounds are gone.\n";
            }
        }

        public override string HealSkill()
        {
            float percentage = (float)0.8;
            if (!GetSpecialTrait())
            {
                float chance = GenerateValue(0, 1, false);
                if (chance >= percentage)
                {
                    SetSpecialTrait(true);
                    SetHeart(GetMaxHeart());
                }
            }
            return HealNarrative();
        }

        public override int MonsterChoice()
        {
            float attack = (float)0.45; // anything less than .35 and the monster will attack
            float choice = GenerateValue(0, 1, false);
            if (choice < attack)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public override string SpecialNarrative(float damage)
        {
            throw new NotImplementedException();
        }

        public override float SpecialSkill()
        {
            throw new NotImplementedException();
        }

    }
}