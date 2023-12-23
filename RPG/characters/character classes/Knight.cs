namespace RPG.characters.character_classes
{
    /// <summary>
    /// Knight | Amazing for beginners, good health and overall attributes!
    /// </summary>
    public class Knight : Character
    {
        public Knight(Type type)
        {
            characterType = type;
        }

        public override string ToString()
        {
            return "Knight";
        }
    }
}
