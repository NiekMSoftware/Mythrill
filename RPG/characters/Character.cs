using System.Runtime.InteropServices;
using RPG.interfaces;

namespace RPG.characters
{
    /// <summary>
    /// Character class inherits both from CharacterData and ICharacter,
    /// which makes it easier for other Character classes to access those methods and properties
    /// </summary>
    public abstract class Character : CharacterData, ICharacter
    {
        Random random = new Random();

        private const int DefenseFactor = 2;

        public int Attack(Character target)
        {
            int damage = CalculateDamage();

            if (target.characterDecision == Decision.Defend)
            {
                damage = target.Defend(this);
            }
            else
            {
                target.TakeDamage(damage);
            }

            return damage;
        }

        public int Defend(Character target)
        {
            // Apply defense to reduce damage taken
            int incomingDamage = target.CalculateDamage();

            // Apply defense to reduce the damage taken
            int reducedDamage = incomingDamage - (Defense * DefenseFactor);
            reducedDamage = Math.Max(reducedDamage, 0);

            // Reduce health
            TakeDamage(reducedDamage);
            Console.WriteLine($"{Name} defended and received {reducedDamage} damage!");

            return reducedDamage;
        }

        public void Parry(Character target)
        {
            // Calculate the damage upon calling this action
            int incomingDamage = target.CalculateDamage();

            int parryReduction = 5; // value might need balancing
            incomingDamage -= parryReduction;

            // Ensure that the damage is not negative
            incomingDamage = Math.Max(incomingDamage, 0);

            Console.WriteLine($"{Name} parried the attack and dealt {incomingDamage} damage!");
        }

        public void UseSkill(Character target)
        {
            // TODO: Implement Skill logic
            Attack(target); // for now just attack
        }

        public int CalculateDamage()
        {
            var baseDamage = Damage;
            var modifiedDamage = (int)(baseDamage * (1 + Strength / 10.0));

            // introduce random variability
            var variability = random.NextDouble() * 0.2 + 0.9;  // between 0.2 and 0.9
            var totalDamage = (int)(modifiedDamage * variability);

            return totalDamage;
        }

        public void TakeDamage(int damage)
        {
            // Apply damage to the character
            Health -= damage;
            
            // Ensure that health doesn't go below 0
            Health = Math.Max(Health, 0);

            Console.WriteLine($"{Name} took {damage} damage!");
        }
    }
}