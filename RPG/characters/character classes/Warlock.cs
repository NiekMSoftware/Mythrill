﻿namespace RPG.characters.character_classes
{
    /// <summary>
    /// Warlock | Very beginner-friendly, increases damage and constitution!
    /// </summary>
    public class Warlock : Character
    {
        public Warlock()
        {
            maxHealth = 30;
            health = maxHealth;
        }

        public override string ToString()
        {
            return "Warlock";
        }
    }
}
