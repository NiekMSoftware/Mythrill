namespace RPG.player_classes
{
    public class PlayerController
    {
        /// <summary>
        /// We store the Movement in a dictionary, so we could easily gather the new index of the player
        /// </summary>
        private Dictionary<ConsoleKey, (int, int)> movement = new ()
        {
            { ConsoleKey.W, (1, 0) },
            { ConsoleKey.A, (0, -1) },
            { ConsoleKey.S, (-1, 0) },
            { ConsoleKey.D, (0, 1) },
            { ConsoleKey.UpArrow, (1, 0) },
            { ConsoleKey.LeftArrow, (0, -1) },
            { ConsoleKey.DownArrow, (-1, 0) },
            { ConsoleKey.RightArrow, (0, 1) }
        };

        // position properties
        public int X { get; set; }
        public int Y { get; set; }

        public const char PlayerChar = '@';
    }
}