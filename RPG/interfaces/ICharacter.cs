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
        /// TakeTurn takes the opposing Character as an opponent
        /// </summary>
        /// <param name="opponent"></param>
        void TakeTurn(Character opponent);

        /// <summary>
        /// AttackEnemy() will attack the opposing Character, this is usually called from TakeTurn()
        /// </summary>
        /// <param name="opponent"></param>
        void AttackEnemy(Character opponent);

        /// <summary>
        /// Defend() will do as it says, it will reduce the damage taken.
        /// </summary>
        void Defend();

        /// <summary>
        /// Heal() will heal up the Character
        /// <code>health += healing</code>
        /// </summary>
        void Heal();

        /// <summary>
        /// TakeDamage() is only called once the Character attacks.
        /// </summary>
        /// <param name="damage"></param>
        void TakeDamage(int damage);

        /// <summary>
        /// TakeSkillPoint() is taking a singular skill point for the character. Forcing for more strategy
        /// </summary>
        /// <param name="skillPoint"></param>
        /// <returns>SkillPoints -= skillPoint;</returns>
        int TakeSkillPoint(int skillPoint);

        /// <summary>
        /// GainSkillPoint() will gain a new skill point based on a certain action that the Character did.
        /// </summary>
        /// <param name="skillPoint"></param>
        /// <returns>SkillPoint += skillPoint</returns>
        int GainSkillPoint(int skillPoint);

        /// <summary>
        /// IsAlive() checks if the Character's health has reached 0. If so it will return true.
        /// </summary>
        /// <returns></returns>
        bool IsAlive();
    }
}