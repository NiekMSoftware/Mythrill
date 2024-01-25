namespace RPG.characters.character_classes
{
    /// <summary>
    /// Knight | Amazing for beginners, good health and overall attributes!
    /// </summary>
    public class Knight : Character
    {
        public Knight()
        {
            strength = 5;
            constitution = 3;
            dexterity = 4;
            intelligence = 2;
            wisdom = 3;
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
            return "Knight";
        }
    }
}
