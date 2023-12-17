namespace MythrillRPG.abstract_classes
{
    public abstract class Character
    {
        public enum CharacterRace
        {
            Dragonborn,
            Elf,
            Human,
            HalfElf,
            Dwarf
        }

        public enum CharacterGender
        {
            Male,
            Female,
            NonBinary,
            ApachiAttackHelicopter // easter egg :D
        }

        // Character Attributes
        protected string characterName;

        protected int health;
        protected int maxHealth;

        protected int level;
        protected int exp;
        protected int maxExp;

        protected int strength;
        protected int constitution;
        protected int dexterity;
        protected int intelligence;
        protected int wisdom;
        protected int charisma;

        protected CharacterRace characterRace;
        protected CharacterGender characterGender;

        #region Public Properties

        public string CharacterName
        {
            get => characterName;
            set => characterName = value ?? throw new ArgumentNullException(nameof(value));
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

        public CharacterRace CharRace
        {
            get => characterRace;
            set => characterRace = value;
        }

        public CharacterGender CharGender
        {
            get => characterGender;
            set => characterGender = value;
        }

        #endregion
    }
}