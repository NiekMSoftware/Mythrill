namespace RPG.player_classes
{
    public class PlayerController
    {
        /// <summary>
        /// We store the Movement in a dictionary, so we could easily gather the new index of the player
        /// </summary>
        public Dictionary<ConsoleKey, (int, int)> Movement = new ()
        {
            { ConsoleKey.W, (0, -1) },
            { ConsoleKey.A, (-1, 0) },
            { ConsoleKey.S, (0 , 1) },
            { ConsoleKey.D, (1 , 0) },
            { ConsoleKey.UpArrow, (0 , -1) },
            { ConsoleKey.LeftArrow, (-1 , 0) },
            { ConsoleKey.DownArrow, (0 , 1) },
            { ConsoleKey.RightArrow, (1 , 0) }
        };

        // position properties
        public int X { get; set; }
        public int Y { get; set; }

        public const char PlayerChar = '@';
    }
}