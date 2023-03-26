
namespace FinalProject.Characters
{
    public abstract class Character
    {
        private string _name;
        private float _heart;
        private float _maxHeart;
        private int _magic;
        private int _maxMagic;
        private float _attack;
        private float _defense;
        private bool _blocking = false;
        private bool _specialTrait = false; // this attribute is different for each character.

        public Character()
        {
        }

        public Character(string name, float heart, int magic, float attack, float defense)
        {
            _name = name;
            _heart = heart;
            _maxHeart = heart;
            _magic = magic;
            _maxMagic = magic;
            _attack = attack;
            _defense = defense;
        }

        // =====================GETTERS=====================

        public string GetName()
        {
            return _name;
        }
        public float GetHeart()
        {
            return _heart;
        }
        public float GetMaxHeart()
        {
            return _maxHeart;
        }
        public int GetMagic()
        {
            return _magic;
        }

        public int GetMaxMagic()
        {
            return _maxMagic;
        }
        public float GetAttack()
        {
            return _attack;
        }
        public float GetDefense()
        {
            return _defense;
        }

        public bool GetBlocking()
        {
            return _blocking;
        }

        public bool GetSpecialTrait()
        {
            return _specialTrait;
        }

        // =====================SETTERS=====================
        public void SetHeart(float heart)
        {
            _heart = heart;
        }
        public void SetMaxHeart(float maxHeart)
        {
            _maxHeart = maxHeart;
        }
        public void SetMaxMagic(int maxMagic)
        {
            _maxMagic = maxMagic;
        }
        public void SetMagic(int magic)
        {
            _magic = magic;
        }
        public void SetAttack(float attack)
        {
            _attack = attack;
        }
        public void SetDefense(float defense)
        {
            _defense = defense;
        }
        public void SetBlocking(bool blocking)
        {
            _blocking = blocking;
        }
        public virtual void SetSpecialTrait(bool trait)
        {
            _specialTrait = trait;
        }

        public float GenerateValue(float min, float max, bool round = true)
        {
            var rand = new Random();
            float num = (float)rand.NextDouble() * (max - min) + min;
            if (round)
            {
                num = (float)(Math.Round(num * 4, MidpointRounding.ToEven) / 4);
            }
            return num;
        }

        public abstract float AttackSkill();
        public abstract string AttackNarrative(float damage);
        public virtual float DefenseSkill()
        {
            if ((_magic + 2) < _maxMagic)
            {
                _magic += 2;
            }
            else
            {
                _magic = _maxMagic;
            }

            return _defense * 2;
        }
        public abstract string DefendNarrative();
        public abstract float SpecialSkill();
        public abstract string SpecialNarrative(float damage);
        public abstract string HealSkill();
        public abstract string HealNarrative();
        public abstract int MonsterChoice();


    }
}