namespace RPG.characters.character_classes
{
    /// <summary>
    /// Bard | Increased charisma, that's about it really!
    /// </summary>
    public class Bard : Character
    {
        public Bard()
        {
            maxHealth = 30;
            health = maxHealth;
        }

        public override string ToString()
        {
            return "Bard";
        }
    }
}