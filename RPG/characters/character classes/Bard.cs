namespace RPG.characters.character_classes
{
    /// <summary>
    /// Bard | Increased charisma, that's about it really!
    /// </summary>
    public class Bard : Character
    {
        public Bard()
        {
            strength = 3;
            constitution = 6;
            dexterity = 5;
            intelligence = 2;
            wisdom = 3;
            charisma = 6;

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
            return "Bard";
        }
    }
}