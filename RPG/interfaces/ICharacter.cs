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
        int Attack(Character target);

        /// <summary>
        /// Defend() is called to reduce the damage taken by the enemy!
        /// </summary>
        /// <param name="target"></param>
        int Defend(Character target);

        /// <summary>
        /// Parry() is called when the opposing Character tries to Attack.
        /// Mainly this function is called for the AI (at this time).
        /// </summary>
        /// <param name="target"></param>
        int Parry(Character target);

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