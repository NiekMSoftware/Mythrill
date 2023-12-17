using MythrillRPG.abstract_classes;
using MythrillRPG.interfaces;

namespace MythrillRPG.classes.character_classes
{
    public class Warlock : Character, ICharacter
    {
        public Warlock(string name, CharacterGender gender, CharacterRace race)
        {
            // set health to max health
            health = maxHealth;

            // set health and exp values
            level = 1;
            exp = 0;
            maxExp = 15;

            // set name, gender and race
            characterName = name;
            characterGender = gender;
            characterRace = race;
        }

        public int ReceiveDamage(int damage)
        {
            return health -= damage;
        }

        public int DealDamage(int damage)
        {
            return damage;
        }

        public void Attack()
        {
            Console.WriteLine("I attack");
        }

        public void Defend()
        {
            Console.WriteLine("I defend");
        }

        public void Dodge()
        {
            Console.WriteLine("SOULS GAMING OH GREAT HEAVENS");
        }

        public void Heal()
        {
            Console.WriteLine("*slurp* NOISE");
        }

        public void UltimateAttack()
        {
            Console.WriteLine("KAME KAME HAAAAAA (fortnite edition)");
        }

        public int TakePoints(int amountOfPoints)
        {
            return (amountOfPoints - 1);
        }

        public int GainPoints(int amountOfPoints)
        {
            return (amountOfPoints + 1);
        }
    }
}