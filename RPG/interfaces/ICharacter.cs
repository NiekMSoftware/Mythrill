namespace RPG.interfaces
{
    /// <summary>
    /// ICharacter interface has the basic functionality
    /// that a character will need throughout the game.
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// Function to lower health of characters, also used to output GUI
        /// </summary>
        protected void Attack();

        /// <summary>
        /// Function to defend, this will make sure lesser health will be removed
        /// based on the other character's damage.
        /// </summary>
        protected void Defend();

        /// <summary>
        /// Function to heal up and gain health, this will make sure the character will survive in this scenario!
        /// </summary>
        protected void Heal();

        /// <summary>
        /// Lowers the skillPoints of the characters
        /// <code>return skillPoints -= skillPoint;</code>
        /// </summary>
        /// <param name="skillPoint"></param>
        /// <returns></returns>
        protected int RemoveSkillPoint(int skillPoint);

        /// <summary>
        /// Increases the skillPoints of the characters
        /// <code>return skillPoints += skillPoint;</code>
        /// </summary>
        /// <param name="skillPoint"></param>
        /// <returns></returns>
        protected int GainSkillPoint(int skillPoint);
    }
}