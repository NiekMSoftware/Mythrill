namespace RPG.characters.character_classes
{
    /// <summary>
    /// Wizard | Increases and intelligence and wisdom. Lower in health but that's to be expected!
    /// </summary>
    public class Wizard : Character
    {
        public Wizard()
        {
            strength = 4;
            constitution = 3;
            dexterity = 2;
            intelligence = 6;
            wisdom = 5;
            charisma = 3;

            maxHealth = (constitution * 10) / 3;
            health = maxHealth;
            defense = (constitution * 3) / 4;
            damage = ((intelligence + wisdom) * 2) / 3;

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
            return "Wizard";
        }
    }
}