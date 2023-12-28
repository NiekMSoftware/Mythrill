using System.Diagnostics;
using System.Runtime.InteropServices;
using RPG.interfaces;

namespace RPG.characters
{
    /// <summary>
    /// Character class inherits both from CharacterData and ICharacter,
    /// which makes it easier for other Character classes to access those methods and properties
    /// </summary>
    public class Character : CharacterData, ICharacter
    {
        Random random = new Random();

        private const int DefenseFactor = 2;

        public int Attack()
        {
            int damage = CalculateDamage();

            return damage;
        }

        public int Defend()
        {
            // Apply defense to reduce damage taken
            int incomingDamage = CalculateDamage();

            // Apply defense to reduce the damage taken
            int reducedDamage = incomingDamage - (Defense * DefenseFactor);
            reducedDamage = Math.Max(reducedDamage, 0);

            return reducedDamage;
        }

        public int Parry()
        {
            // Calculate the damage upon calling this action
            int incomingDamage = CalculateDamage();

            int parryReduction = 5; // value might need balancing
            incomingDamage -= parryReduction;

            // Ensure that the damage is not negative
            incomingDamage = Math.Max(incomingDamage, 0);

            return incomingDamage;
        }

        public void UseSkill()
        {
            // TODO: Implement Skill logic
            Attack(); // for now just attack
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
    }
}