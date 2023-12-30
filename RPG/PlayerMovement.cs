using System.Diagnostics;
using RPG.game_states;

namespace RPG
{
    public class PlayerMovement
    {
        private const char PlayerChar = '@';
        private const int Delay = 16;

        private int x = 0;
        private int y = 0;

        public void Start()
        {
            Console.CursorVisible = false;

            // Set initial player position to the center of the room
            x = RoomGenerator.Width / 2;
            y = RoomGenerator.Height / 2;

            // Calculate the center of the console window
            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;

            // Set the current position in the 2d char array to the player char
            Console.SetCursorPosition(centerX + x - RoomGenerator.Width / 2, centerY + y - RoomGenerator.Height / 2);
            Console.Write(PlayerChar);

            while (true)
            {
                HandleInput();
                Thread.Sleep(Delay);
            }
        }

        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        Move(0, 1);
                        break;
                    case ConsoleKey.UpArrow:
                        Move(0, -1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Move the player
        private void Move(int dx, int dy)
        {
            // Calculate new position
            int newX = x + dx;
            int newY = y + dy;

            // Get the room dimensions
            int roomWidth = RoomGenerator.Width;
            int roomHeight = RoomGenerator.Height;

            // Check if the new position is within the room boundaries
            if (newX >= 1 && newX < roomWidth - 1 && newY >= 1 && newY < roomHeight - 1)
            {
                // Calculate the center of the console window
                int centerX = Console.WindowWidth / 2;
                int centerY = Console.WindowHeight / 2;

                // Clear the current position
                Console.SetCursorPosition(centerX + x - roomWidth / 2, centerY + y - roomHeight / 2);
                Console.Write(' ');

                // Update the current position
                x = newX;
                y = newY;

                // Set the current position in the 2d char array to the player char
                Console.SetCursorPosition(centerX + x - roomWidth / 2, centerY + y - roomHeight / 2);
                Console.Write(PlayerChar);
            }
        }
    }
}