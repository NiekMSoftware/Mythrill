using RPG.interfaces;

namespace RPG.characters
{
    /// <summary>
    /// Character class inherits both from CharacterData and ICharacter,
    /// which makes it easier for other Character classes to access those methods and properties
    /// </summary>
    public abstract class Character : CharacterData, ICharacter
    {
        public void Attack(Character target)
        {
            Console.WriteLine($"{Name} dealt {CalculateDamage()} damage to {target.Name}");

            // Deal damage to target
            target.TakeDamage(CalculateDamage());
        }

        public void Defend(Character target)
        {
            throw new NotImplementedException("Not yet implemented.");
        }

        public void UseSkill(Character target)
        {
            // TODO: Implement Skill logic
            Attack(target);
        }

        public int CalculateDamage()
        {
            var baseDamage = Damage;
            var modifiedDamage = (int)(baseDamage * (1 + Strength / 10.0));

            // introduce random variability
            Random random = new Random();
            var variability = random.NextDouble() * 0.2 + 0.9;  // between 0.2 and 0.9
            var totalDamage = (int)(modifiedDamage * variability);

            return totalDamage;
        }
    }
}