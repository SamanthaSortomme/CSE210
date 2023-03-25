namespace FinalProject.Characters
{
    public class Scrub : Character
    {
        public Scrub(string _name, float heart, int magic, float attack, float defense) : base(_name, heart, magic, attack, defense)
        {
        }

        public override string AttackNarrative(float damage)
        {
            return $"You see a Deku Nut fly at your face. {damage} hearts worth of damage knock the wind out of you.";
        }

        public override float AttackSkill()
        {
            return (float)0.25 + GetAttack();
        }

        public override string DefendNarrative()
        {
            return $"He plops in the ground, you missed him this time.";
        }

        public override float DefenseSkill()
        {
            SetBlocking(true);
            return 0;
        }

        public override string HealNarrative()
        {
            return $"He appears healthier than he used to be... /fail";
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
                    return "The Scrub gets knocked out of it's hidey-hole and flounders for a moment before regaining it's composure and quickly diving back in. You're not sure, but it seems it's wounds are gone.\n";
                }
            }
            return "The Scrub gets knocked out of it's hidey-hole and flounders for a moment before it stops moving.\n";
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