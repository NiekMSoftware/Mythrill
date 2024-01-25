using System.Diagnostics;
using RPG.characters.character_classes;
using RPG.interfaces;

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

        public Enemy()
        {
            // Create enemy
            CreateEnemy();
            
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

        private void ApplyStats()
        {
            switch (enemyType)
            {
                case EnemyType.Skeleton:
                    strength = 3;
                    constitution = 3;
                    dexterity = 4;
                    intelligence = 2;
                    wisdom = 1;
                    charisma = 2;

                    maxHealth = (constitution * 10) / 3;
                    health = maxHealth;
                    defense = (constitution * 3) / 4;
                    damage = (strength * 2) / 3;

                    level = 1;
                    exp = 0;
                    maxExp = (level * 10) / 2;
                    skillPoints = 5;
                    break;

                case EnemyType.Goblin:
                    strength = 4;
                    constitution = 2;
                    dexterity = 4;
                    intelligence = 1;
                    wisdom = 1;
                    charisma = 1;

                    maxHealth = (constitution * 10) / 3;
                    health = maxHealth;
                    defense = (constitution * 3) / 4;
                    damage = (strength * 2) / 3;

                    level = 1;
                    exp = 0;
                    maxExp = (level * 10) / 2;
                    skillPoints = 5;
                    break;

                case EnemyType.Warrior:
                    strength = 4;
                    constitution = 5;
                    dexterity = 5;
                    intelligence = 3;
                    wisdom = 4;
                    charisma = 5;

                    maxHealth = (constitution * 10) / 3;
                    health = maxHealth;
                    defense = (constitution * 3) / 4;
                    damage = (strength * 2) / 3;

                    level = 1;
                    exp = 0;
                    maxExp = (level * 10) / 2;
                    skillPoints = 5;
                    break;

                case EnemyType.Valkyrie:
                    strength = 6;
                    constitution = 6;
                    dexterity = 5;
                    intelligence = 5;
                    wisdom = 6;
                    charisma = 6;

                    maxHealth = (constitution * 10) / 3;
                    health = maxHealth;
                    defense = (constitution * 3) / 4;
                    damage = (strength * 2) / 3;

                    level = 1;
                    exp = 0;
                    maxExp = (level * 10) / 2;
                    skillPoints = 5;
                    break;
            }
        }
    }
}