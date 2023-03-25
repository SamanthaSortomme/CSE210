namespace FinalProject.Characters
{
    public class Hylian : Character
    {
        public Hylian(string name, float heart, int magic, float attack, float defense) : base(name, heart, magic, attack, defense)
        {
        }

        public override float AttackSkill()
        {
            float min = (float)0.25;
            float max = (float)0.75;
            float attack = GenerateValue(min, max) + GetAttack();// return number between min and max
            return attack;
        }


        public void ResetHeal()
        {
            if (GetSpecialTrait())
            {
                float chance = GenerateValue(0, 1, false);
                // chance = (float)Math.Round(chance, MidpointRounding.ToEven);
                if (chance >= 0.8)
                {
                    SetSpecialTrait(false);
                    Console.Write($"After the battle ended you found a fairy. Since your bottle is empty you quickly coax it into the bottle with the promise of adventure. Your ability to cheat death has been regained!\n");
                }
            }
        }
        public override float DefenseSkill()
        {
            return base.DefenseSkill();
        }

        public override string HealSkill()
        {
            if (!GetSpecialTrait())
            {
                SetSpecialTrait(true);
                SetHeart(GetMaxHeart());
                return "You fall. Flat on your face in an extremely inelegant manner with a sound of *PLAP*. the cork on the jar you keep your trusty travel companion in pops off setting the prison... er... eager adventure free. The fairy sneezes as she leaves which inadvertently heals all of your wounds. including that one from years ago when you fell off your bike.\n";
            }
            return "You fall. Flat on your face in an extremely inelegant manner with a sound of *PLAP*. unfortunately your fairy motel is currently vacant, thus there is no stupidly miraculously recovery. I guess everyone's luck runs out some time.\n";
        }

        public override int MonsterChoice()
        {
            throw new NotImplementedException();
        }

        public override float SpecialSkill()
        {
            int magic = GetMagic();
            if (magic >= 2)
            {
                magic -= 2;
                SetMagic(magic);
                float attack = AttackSkill();
                attack += AttackSkill();
                return attack;
            }
            else
            {
                Console.Write("Not enough magic power to execute this attack.\n");
                return 0;
            }
        }

        public override string AttackNarrative(float damage)
        {
            return $"You swing your sword with all your might and  deal {damage} hearts worth of damage.";
        }

        public override string DefendNarrative()
        {
            return $"You block with your shield and prevent all damage.";
        }

        public override string SpecialNarrative(float damage)
        {
            return $"You draw your bow, put an ice arrow and let it fly, {damage} hearts worth of damage pierce your enemy.";
        }

        public override string HealNarrative()
        {
            return $"You heal.";
        }
    }
}