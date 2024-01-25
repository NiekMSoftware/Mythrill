﻿namespace RPG.characters.character_classes
{
    /// <summary>
    /// Wizard | Increases and intelligence and wisdom. Lower in health but that's to be expected!
    /// </summary>
    public class Wizard : Character
    {
        public Wizard()
        {
            health = maxHealth;
        }

        public override string ToString()
        {
            return "Wizard";
        }
    }
}