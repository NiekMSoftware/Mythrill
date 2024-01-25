namespace RPG.characters.character_classes
{
    /// <summary>
    /// Warlock | Very beginner-friendly, increases damage and constitution!
    /// </summary>
    public class Warlock : Character
    {
        public Warlock()
        {
            strength = 5;
            constitution = 4;
            dexterity = 3;
            intelligence = 3;
            wisdom = 4;
            charisma = 5;

            maxHealth = (constitution * 10) / 3;
            health = maxHealth;
            defense = (constitution * 3) / 4;
            damage = (strength * 2) / 3;

            level = 1;
            exp = 0;
            maxExp = (level * 10) / 2;
            skillPoints = 5;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            maxHealth = (constitution * 10) / 3;
            health = maxHealth;
        }

        public override string ToString()
        {
            return "Warlock";
        }
    }
}
