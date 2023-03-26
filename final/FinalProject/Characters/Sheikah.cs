namespace FinalProject.Characters
{
    public class Sheikah : Character
    {
        public Sheikah(string _name, float heart, int magic, float attack, float defense) : base(_name, heart, magic, attack, defense)
        {
        }

        public override string AttackNarrative(float damage)
        {
            return $"You launch your hookshot, it's a hit! {damage} hearts worth of damage was dealt.\n";
        }

        public override float AttackSkill()
        {
            return (float)0.25 + GetAttack();
        }

        public override string DefendNarrative()
        {
            return $"You hone in all your focus on your enemies movements, prepared to evade anything that comes your way.\n";
        }

        public override float DefenseSkill()
        {
            return base.DefenseSkill();
        }

        public override string HealNarrative()
        {
            if (GetMagic() > 1)
            {
                return $"Calling on spirits of the past you feel your wounds bind themselves.\n";
            }
            else
            {
                return $"You attempt to call upon your healing magics but your mind is too muddled to recite the correct formula\n";
            }
        }

        public override string HealSkill()
        {
            int magic = GetMagic();
            string narrative;
            if (magic >= 2)
            {
                narrative = HealNarrative();
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
            }
            else
            {
                narrative = HealNarrative();
            }
            return narrative;

        }

        public override int MonsterChoice()
        {
            throw new NotImplementedException();
        }

        public override string SpecialNarrative(float damage)
        {
            if (damage > 0)
            {
                return $"Magic flows out of you and a sphere of flame bursts forth. {damage} hearts worth of damage is dealt to your foe!\n";
            }
            else
            {
                return $"You try to recite the words of your spell but lack the magical power to make the words flow.\n";
            }
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
                return 0;
            }
        }

    }
}