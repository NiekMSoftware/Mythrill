using RPG.characters;

namespace RPG.interfaces
{
    /// <summary>
    /// ICharacter interface has the basic functionality
    /// that a character will need throughout the game.
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// Function Attack() is used to attack the opposing Character target.
        /// </summary>
        /// <param name="target"></param>
        void Attack(Character target);

        /// <summary>
        /// Defend() is called to reduce the damage taken by the enemy!
        /// </summary>
        /// <param name="target"></param>
        void Defend(Character target);

        /// <summary>
        /// A skill will deal more damage than a regular attack.
        /// Use this method only when the Character saved up enough points.
        /// </summary>
        /// <param name="target"></param>
        void UseSkill(Character target);

        /// <summary>
        /// CalculateDamage() is called every Attack() sequence, function will calculate the
        /// damage to each attack accordingly.
        /// </summary>
        /// <returns></returns>
        int CalculateDamage();
    }
}