namespace MythrillProject.interfaces
{
    // Create an interface that keeps track of all the attributes
    public interface ICharacter
    {
        // Base attributes
        protected string Name { get; set; }
        protected int Health { get; set; }
        protected int MaxHealth { get; set; }
        protected int Speed { get; set; }
        
        // Leveling
        protected int Level { get; set; }
        protected int Exp { get; set; }
        protected int MaxExp { get; set; }
        
        // Advanced attributes
        protected int Strength { get; set; }
        protected int Intelligence { get; set; }
        protected int Wisdom { get; set; }
        protected int Dexterity { get; set; }
        protected int Constitution { get; set; }
        protected int Charisma { get; set; }
    }
}