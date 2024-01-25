using System.Diagnostics;
using RPG.characters.character_classes;
using RPG.interfaces;
using RPG.player_classes;

namespace RPG.characters
{
    public class Enemy : Character
    {
        public enum EnemyType
        {
            Skeleton,
            Valkyrie,
            Goblin,
            Warrior
        }

        private static string[] maleNames = new[]
        {
            "Gerald",
            "Bob",
            "Colin",
            "Henk",
            "Gerard",
            "Gert",
            "Steve",
            "Motaki Tanigo",
            "Hidetaka Miyazaki",
            "Hideoka Kojima"
        };

        private static string[] femaleNames = new[]
        {
            "Calliope",
            "Kiara",
            "Irys",
            "Henk",
            "Yoshi",
            "Nerissa",
            "Ayame",
            "Majka",
            "Towa",
            "Ina"
        };

        public EnemyType enemyType;

        private Character player;

        // stat modifier will increase after each player level
        private float statModifier = 0.2f;

        public Enemy(Character player)
        {
            this.player = player;
            
            // Create enemy
            CreateEnemy();

            // Check player level
            while (level != player.Level)
            {
                level++;
            }

            // apply stat changes
            ApplyStats();
        }

        private void CreateEnemy()
        {
            // Instantiate a random value
            var random = new Random();

            // set enemy class
            var enemyTypes = Enum.GetValues(typeof(EnemyType));
            enemyType = (EnemyType)enemyTypes.GetValue(random.Next(enemyTypes.Length));
            Debug.WriteLine($"EnemyType is: {enemyType}");

            // set enemy race
            var races = Enum.GetValues(typeof(Race));
            Race race;
            do
            {
                characterRace = (Race)races.GetValue(random.Next(races.Length));
            } while (characterRace == Race.None);

            // set gender
            var genders = Enum.GetValues(typeof(Gender));
            Gender gender;
            do
            {
                characterGender = (Gender)genders.GetValue(random.Next(genders.Length));
            }while (characterGender == Gender.None);

            // set enemy name based on gender
            name = characterGender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];
        }

        private float LevelModifier()
        {
            float pLevel = player.Level;
            return statModifier += pLevel;
        }

        private void ApplyStats()
        {
            float s = 3;
            float c = 3;
            float d = 4;
            float i = 2;
            float w = 1;
            float ch = 2;

            switch (enemyType)
            {
                case EnemyType.Skeleton:
                    strength = (int)(s *= LevelModifier());
                    constitution = (int)(c *= LevelModifier());
                    dexterity = (int)(d *= LevelModifier());
                    intelligence = (int)(i *= LevelModifier());
                    wisdom = (int)(w *= LevelModifier());
                    charisma = (int)(ch *= LevelModifier());

                    maxHealth = (constitution * 10) / 3;
                    health = maxHealth;
                    defense = (constitution * 3) / 4;
                    damage = (strength * 2) / 3;
                    break;

                case EnemyType.Goblin:
                    s = 4;
                    c = 2;
                    d = 4;
                    i = 1;
                    w = 1;
                    ch = 1;

                    strength = (int)(s *= LevelModifier());
                    constitution = (int)(c *= LevelModifier());
                    dexterity = (int)(d *= LevelModifier());
                    intelligence = (int)(i *= LevelModifier());
                    wisdom = (int)(w *= LevelModifier());
                    charisma = (int)(ch *= LevelModifier());

                    maxHealth = (constitution * 10) / 3;
                    health = maxHealth;
                    defense = (constitution * 3) / 4;
                    damage = (strength * 2) / 3;
                    break;

                case EnemyType.Warrior:
                    s = 5;
                    c = 4;
                    d = 5;
                    i = 4;
                    w = 3;
                    ch = 5;

                    strength = (int)(s *= LevelModifier());
                    constitution = (int)(c *= LevelModifier());
                    dexterity = (int)(d *= LevelModifier());
                    intelligence = (int)(i *= LevelModifier());
                    wisdom = (int)(w *= LevelModifier());
                    charisma = (int)(ch *= LevelModifier());

                    maxHealth = (constitution * 10) / 3;
                    health = maxHealth;
                    defense = (constitution * 3) / 4;
                    damage = (strength * 2) / 3;
                    break;

                case EnemyType.Valkyrie:
                    s = 6;
                    c = 6;
                    d = 5;
                    i = 6;
                    w = 6; 
                    ch = 6;

                    strength = (int)(s *= LevelModifier());
                    constitution = (int)(c *= LevelModifier());
                    dexterity = (int)(d *= LevelModifier());
                    intelligence = (int)(i *= LevelModifier());
                    wisdom = (int)(w *= LevelModifier());
                    charisma = (int)(ch *= LevelModifier());

                    maxHealth = (constitution * 10) / 3;
                    health = maxHealth;
                    defense = (constitution * 3) / 4;
                    damage = (strength * 2) / 3;
                    break;
            }
        }
    }
}