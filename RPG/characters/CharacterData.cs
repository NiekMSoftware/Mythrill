using RPG.characters.character_classes;

namespace RPG.characters
{
    public class CharacterData
    {
        public enum Race
        {
            None,
            Dragonborn,
            Human,
            HalfElf,
            Elf
        }

        public enum Gender
        {
            Male,
            Female,
            None
        }

        public enum Decision
        {
            None,
            Attack,
            Defend,
            Parry
        }

        public CharacterData()
        {
            name = "";

            characterRace = Race.None;
            characterGender = Gender.None;
        }

        protected string name;

        protected int health;
        protected int maxHealth;
        protected int defense;
        protected int damage;

        protected int level;
        protected int exp;
        protected int maxExp;
        protected int skillPoints;

        // Attributes
        protected int strength;
        protected int constitution;
        protected int dexterity;
        protected int intelligence;
        protected int wisdom;
        protected int charisma;

        protected bool defending;
        protected bool isDead;

        #region Public Properties

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Health
        {
            get => health;
            set => health = value;
        }

        public int MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        public int Defense
        {
            get => defense;
            set => defense = value;
        }

        public int Damage
        {
            get => damage;
            set => damage = value;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public int Exp
        {
            get => exp;
            set => exp = value;
        }

        public int MaxExp
        {
            get => maxExp;
            set => maxExp = value;
        }

        public int SkillPoints
        {
            get => skillPoints;
            set => skillPoints = value;
        }

        public int Strength
        {
            get => strength;
            set => strength = value;
        }

        public int Constitution
        {
            get => constitution;
            set => constitution = value;
        }

        public int Dexterity
        {
            get => dexterity;
            set => dexterity = value;
        }

        public int Intelligence
        {
            get => intelligence;
            set => intelligence = value;
        }

        public int Wisdom
        {
            get => wisdom;
            set => wisdom = value;
        }

        public int Charisma
        {
            get => charisma;
            set => charisma = value;
        }

        public bool Defending
        {
            get => defending;
            set => defending = value;
        }

        public bool IsAlive() => Health > 0;

        public bool IsDefending() => Defending;

        public Race characterRace;
        public Gender characterGender;
        public Decision characterDecision;
        
        #endregion

        public void LevelUp()
        {
            level++;
            exp -= maxExp;
            maxExp += level * 10;

            switch (this)
            {
                // increase attributes based on class
                case Knight:
                    strength += 4;
                    constitution += 3;
                    dexterity += 5;
                    intelligence += 3;
                    wisdom += 2;
                    charisma += 6;
                    break;

                case Wizard:
                    strength += 2;
                    constitution += 4;
                    dexterity += 3;
                    intelligence += 6;
                    wisdom += 5;
                    charisma += 3;
                    break;

                case Warlock:
                    strength += 6;
                    constitution += 4;
                    dexterity = 4;
                    intelligence += 2;
                    wisdom += 3;
                    charisma += 5;
                    break;

                case Bard:
                    strength += 2;
                    constitution += 4;
                    dexterity += 5;
                    intelligence += 2;
                    wisdom += 3;
                    charisma += 6;
                    break;

                case Berserk:
                    strength += 5;
                    constitution += 3;
                    dexterity += 4;
                    intelligence += 2;
                    wisdom += 3;
                    charisma += 5;
                    break;
            }
        }
    }
}