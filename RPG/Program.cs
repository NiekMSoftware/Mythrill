﻿using RPG.game_states.endless;

namespace RPG
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game();
            game.RunLoop();
        }
    }
}