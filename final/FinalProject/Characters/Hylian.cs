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


        public override void SetSpecialTrait(bool trait)
        {
            if (trait == true)
            {
                base.SetSpecialTrait(trait);
            }
            else
            {
                float chance = GenerateValue(0, 1, false);
                // chance = (float)Math.Round(chance, MidpointRounding.ToEven);
                if (chance >= 0.8)
                {
                    base.SetSpecialTrait(false);
                    Console.Write($"After the battle ended you found a fairy. Since your bottle is empty you quickly coax it into the bottle with the promise of adventure. Your ability to cheat death has been regained!\n");
                    ConsoleUtilities.WaitForKeyPress();
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
            }
            return HealNarrative();
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
                return 0;
            }
        }

        public override string AttackNarrative(float damage)
        {
            return $"You swing your sword with all your might and deal {damage} hearts worth of damage.\n";
        }

        public override string DefendNarrative()
        {
            return $"You ready your shield and watch your enemy closely.\n";
        }

        public override string SpecialNarrative(float damage)
        {
            if (damage > 0)
            {
                return $"You channel energy into your sword then swing with all your might creating a expanding ring of energy! You deal {damage} hearts worth of damage to your enemy.\n";
            }
            else
            {
                return "You attempt to channel energy to your blade, but find yourself too mentally taxed to do so.\n";
            }
        }

        public override string HealNarrative()
        {
            if (GetHeart() > 0)
            {
                return $"You fall. Flat on your face. In an extremely inelegant manner with a sound of *PLAP*. The cork on the jar you keep your trusty travel companion in pops off setting the priso... er... eager fairy \"adventurer\" free. The fairy sneezes as she leaves which inadvertently heals all of your wounds.\n";
            }
            else
            {
                return "You fall. Flat on your face. In an extremely inelegant manner with a sound of *PLAP*. Unfortunately your fairy motel is currently vacant. Thus there is no stupidly miraculous recovery. I guess everyone's luck runs out some time.\n";
            }
        }
    }
}