namespace FinalProject.Characters
{
    public class Sheikah : Character
    {
        public Sheikah(string _name, float heart, int magic, float attack, float defense) : base(_name, heart, magic, attack, defense)
        {
        }

        public override string AttackNarrative(float damage)
        {
            return $"You launch your hookshot, it's a hit! {damage} hearts worth of damage was dealt.";
        }

        public override float AttackSkill()
        {
            return (float)0.25 + GetAttack();
        }

        public override string DefendNarrative()
        {
            return $"You see the attack coming from a mile away, quickly you blind your enemy with sand and do a back flip, avoiding all damage.";
        }

        public override float DefenseSkill()
        {
            return base.DefenseSkill();
        }

        public override string HealNarrative()
        {
            return $"Calling on spirits of the past you feel your wounds bind themselves.";
        }

        public override string HealSkill()
        {
            int magic = GetMagic();
            if (magic >= 2)
            {
                magic -= 2;
                SetMagic(magic);
                float heal = GetMaxHeart() * (float)0.75;
                float currentHearts = GetHeart();
                if (currentHearts + heal <= GetMaxHeart())
                {
                    SetHeart((currentHearts + heal));
                }
                else
                {
                    SetHeart(GetMaxHeart());
                }
                return "You close your eyes and recite the familiar words of healing and feel the pain of your wounds soothed.\n";
            }
            return "You attempt to call upon your healing magics but your mind is too muddled to recite the correct formula\n";
        }

        public override int MonsterChoice()
        {
            throw new NotImplementedException();
        }

        public override string SpecialNarrative(float damage)
        {
            return $"Magic flows out of you, BAM! {damage} hearts worth of damage taken by all foes around you.";
        }

        public override float SpecialSkill()
        {
            int magic = GetMagic();
            if (magic >= 4)
            {
                magic -= 4;
                SetMagic(magic);
                float min = (float)0.25;
                float max = (float)0.75;
                float attack = (GenerateValue(min, max) + GetAttack()) * 2;
                return attack;
            }
            else
            {
                Console.Write("Not enough magic power to execute this attack.\n");
                return 0;
            }
        }

    }
}