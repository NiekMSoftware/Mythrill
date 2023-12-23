﻿using System.Diagnostics;
using RPG.characters.character_classes;
using RPG.interfaces;

namespace RPG.characters
{
    public class Enemy : Character
    {
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

        public Enemy()
        {
            characterType = Type.Enemy;
        }

        public static Character CreateEnemy(Character enemy)
        {
            // Instantiate a random value
            var random = new Random();

            // Set enemy's class
            var enemyClass = random.Next(0, 5);
            enemy = enemyClass switch
            {
                0 => new Bard(Type.Enemy),
                1 => new Berserk(Type.Enemy),
                2 => new Knight(Type.Enemy),
                3 => new Warlock(Type.Enemy),
                4 => new Wizard(Type.Enemy),
                _ => enemy
            };

            // Set enemy's race
            do
            {
                var index = random.Next(0, 4);
                switch (index)
                {
                    case 0:
                        enemy.characterRace = Race.Dragonborn;
                        break;
                    case 1:
                        enemy.characterRace = Race.Human;
                        break;
                    case 2:
                        enemy.characterRace = Race.HalfElf;
                        break;
                    case 3:
                        enemy.characterRace = Race.Elf;
                        break;
                    default:
                        enemy.characterRace = Race.None;
                        Debug.WriteLine($"Index: {index} is out of bounds!");
                        break;
                }
            } while (enemy.characterRace == Race.None);

            // Set enemy's gender
            while (enemy.characterGender == Gender.None)
            {
                var index = random.Next(0, 2);
                enemy.characterGender = index switch
                {
                    0 => Gender.Male,
                    1 => Gender.Female,
                    _ => Gender.None
                };
            }

            // randomize the enemy's name
            switch (enemy.characterGender)
            {
                // Set enemy's name based on gender
                case Gender.Male:
                    var i = random.Next(maleNames.Length);
                    enemy.Name = maleNames[i];
                    break;
                case Gender.Female:
                    var j = random.Next(femaleNames.Length);
                    enemy.Name = femaleNames[j];
                    break;
                case Gender.None:
                    Debug.WriteLine("Picked none (shouldn't happen).");
                    break;
                default:
                    Debug.WriteLine("No gender!");
                    break;
            }

            Debug.WriteLine($"Enemy name: {enemy.Name}\n" +
                            $"Enemy class: {enemy}\n" +
                            $"Enemy Race: {enemy.characterRace}\n" +
                            $"Enemy Gender: {enemy.characterGender}");

            return enemy;
        }

        public static Enemy EnemyChoice(Enemy enemy)
        {
            return enemy;
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Defend()
        {
            throw new NotImplementedException();
        }

        public override void Heal()
        {
            throw new NotImplementedException();
        }

        public int RemoveSkillPoint(int skillPoint)
        {
            throw new NotImplementedException();
        }

        public int GainSkillPoint(int skillPoint)
        {
            return 0;
        }
    }
}