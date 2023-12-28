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
        int Attack();

        /// <summary>
        /// Defend() is called to reduce the damage taken by the enemy!
        /// </summary>
        int Defend();

        /// <summary>
        /// Parry() is called when the opposing Character tries to Attack.
        /// Mainly this function is called for the AI (at this time).
        /// </summary>
        int Parry();

        /// <summary>
        /// A skill will deal more damage than a regular attack.
        /// Use this method only when the Character saved up enough points.
        /// </summary>
        void UseSkill();

        /// <summary>
        /// CalculateDamage() is called every Attack() sequence, function will calculate the
        /// damage to each attack accordingly.
        /// </summary>
        /// <returns></returns>
        int CalculateDamage();
    }
}