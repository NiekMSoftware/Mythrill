namespace RPG.characters
{
    public class CharacterData
    {
        public CharacterData()
        {
            name = "";

            health = maxHealth;
            maxHealth = (constitution * 10) / 3;
            defense = 6;
            damage = 9;

            level = 1;
            exp = 0;
            maxExp = 12;
            skillPoints = 5;

            strength = (3 * damage) / 4;
            constitution = 5;
            dexterity = 11;     // will increase the chance to dodge
            intelligence = 6;
            wisdom = 8;
            charisma = 1;

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

        public Race characterRace;
        public Gender characterGender;

        #endregion
    }

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
        None,
        Male,
        Female,
        AttackHelicopter
    }
}