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
            // set the stats based on the type
        }

        public void CreateEnemy()
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

            // set scaling factor based on the enemy type
        }
    }
}