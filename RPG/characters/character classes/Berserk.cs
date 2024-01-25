namespace RPG.characters.character_classes
{
    /// <summary>
    /// Berserk class | Increases damage and constitution by default
    /// </summary>
    public class Berserk : Character
    {
        public Berserk()
        {
            strength = 5;
            constitution = 4;
            dexterity = 5;
            intelligence = 3;
            wisdom = 2;
            charisma = 3;

            maxHealth = (constitution * 10) / 3;
            health = maxHealth;
            defense = (constitution * 3) / 4;
            damage = (strength * 2) / 3;

            level = 1;
            exp = 0;
            maxExp = (level * 10) / 2;
            skillPoints = 5;
        }

        public override string ToString()
        {
            return "Berserk";
        }
    }
}