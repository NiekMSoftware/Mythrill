namespace RPG.characters.character_classes
{
    /// <summary>
    /// Bard | Increased charisma, that's about it really!
    /// </summary>
    public class Bard : Character
    {
        public Bard(Type type)
        {
            characterType = type;
        }
        public override string ToString()
        {
            return "Bard";
        }
    }
}