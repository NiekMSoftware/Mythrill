namespace RPG.characters.character_classes
{
    /// <summary>
    /// Berserk class | Increases damage and constitution by default
    /// </summary>
    public class Berserk : Character
    {
        public Berserk()
        {
            maxHealth = 30;
            health = maxHealth;
        }

        public override string ToString()
        {
            return "Berserk";
        }
    }
}