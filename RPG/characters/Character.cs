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

        public int Attack(Character target)
        {
            int damage = CalculateDamage();

            return damage;
        }

        public int Defend(Character target)
        {
            // Calculate the damage upon calling this action
            int incomingDamage = target.CalculateDamage();

            // Apply defense to reduce damage taken
            int defenseFactor = 2;  // Might adjust later
            int reducedDamage = incomingDamage - (Defense * defenseFactor);

            // Ensure damage is not negative
            reducedDamage = Math.Max(reducedDamage, 0);

            Health -= reducedDamage;
            Console.WriteLine($"{Name} defended and received {reducedDamage} damage!");

            return reducedDamage;
        }

        public void Parry(Character target)
        {
            // Calculate the damage upon calling this action
            int incomingDamage = target.CalculateDamage();

            int parryReduction = 2; // value might need balancing
            incomingDamage -= parryReduction;

            // Ensure that the damage is not negative
            incomingDamage = Math.Max(incomingDamage, 0);

            Console.WriteLine($"{Name} parried the attack and dealt {incomingDamage} damage!");
        }

        public Decision AiDecision(Character target)
        {
            Decision aiDecision;

            switch (target.characterDecision)
            {
                case Decision.Attack:
                    int decision = random.Next(1, 4);
                    aiDecision = (Decision)decision;
                    return characterDecision;
                case Decision.Defend:
                    aiDecision = Decision.Attack;
                    break;
                default:
                    aiDecision = Decision.Attack;
                    break;
            }

            characterDecision = aiDecision;
            return aiDecision;
        }

        public void ProcessDecision(Character target)
        {
            switch (AiDecision(target))
            {
                case Decision.Attack:
                    Attack(target);
                    break;
                case Decision.Defend:
                    Defend(target);
                    break;
                case Decision.Parry:
                    Parry(target);
                    break;
            }
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
    }
}