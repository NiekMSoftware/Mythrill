using RPG.characters;
using RPG.user_interface;

namespace RPG.game_states
{
    public class RoomGenerator : GameState
    {
        // Create basic properties for a room
        public static char[,]? Room { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }

        // Create a constructor that takes width and height as parameters
        public RoomGenerator(Stack<GameState> gameStates, List<Character> characters, int width, int height) : base(gameStates, characters)
        {
            // Set the width and height properties
            Width = width;
            Height = height;

            // Create a new 2d char array with the width and height
            Room = new char[width, height];

            // Generate the room
            GenerateRoom('#', ' ');

            // Center the room
            CenterRoom();

            // Spawn the player
            SpawnPlayer();

            // Spawn enemies
            SpawnEnemies();

            PlayerMovement movement = new();
            movement.Start();
        }

        // Create a method that generates a room and that also takes in two chars as parameters, this method will also hollow out the room
        public void GenerateRoom(char wallChar, char floorChar)
        {
            // Loop through the 2d char array
            for (int y = 0; y < Height; y++)
            {
                // Loop through the 2d char array
                for (int x = 0; x < Width; x++)
                {
                    // If the current position is on the edge of the 2d char array
                    if (x == 0 || x == Width - 1 || y == 0 || y == Height - 1)
                    {
                        // Set the current position in the 2d char array to the wall char
                        if (Room != null) 
                            Room[x, y] = wallChar;
                    }
                    // Else if the current position is not on the edge of the 2d char array
                    else
                    {
                        // Set the current position in the 2d char array to the floor char
                        if (Room != null) 
                            Room[x, y] = floorChar;
                    }
                }
            }
        }

        // Create a method that will center the room to the console window
        public void CenterRoom()
        {
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Get the current console window width divided by 2
            int halfConsoleWidth = consoleWidth / 2;

            // Get the current console window height divided by 2
            int halfConsoleHeight = consoleHeight / 2;

            // Get the current room width divided by 2
            int halfRoomWidth = Width / 2;

            // Get the current room height divided by 2
            int halfRoomHeight = Height / 2;

            int startX = halfConsoleWidth - halfRoomWidth;
            int startY = halfConsoleHeight - halfRoomHeight;

            Console.Clear();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.SetCursorPosition(startX + x, startY + y);
                    if (Room != null) 
                        Console.Write(Room[x, y]);
                }
            }
        }

        // Spawn the player and make sure it's in the center of the room and centered to the console window
        public void SpawnPlayer()
        {
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Get the current console window width divided by 2
            int halfConsoleWidth = consoleWidth / 2;

            // Get the current console window height divided by 2
            int halfConsoleHeight = consoleHeight / 2;

            // Get the current room width divided by 2
            int halfRoomWidth = Width / 2;

            // Get the current room height divided by 2
            int halfRoomHeight = Height / 2;

            int startX = halfConsoleWidth - halfRoomWidth;
            int startY = halfConsoleHeight - halfRoomHeight;

            // Set the current position in the 2d char array to the player char
            Console.SetCursorPosition(startX + halfRoomWidth, startY + halfRoomHeight);
        }

        // Create a method that will spawn in enemies in a room
        public void FindPosEnemy()
        {
            // Create a random object
            Random random = new();

            // Create a random number between 1 and 5
            int randomNum = random.Next(1, 5);

            // Loop through the random number
            for (int i = 0; i < randomNum; i++)
            {
                // Create a random x position
                int randomX = random.Next(1, Width - 1);

                // Create a random y position
                int randomY = random.Next(1, Height - 1);

                // Set the current position in the 2d char array to the enemy char
                if (Room != null)
                    Room[randomX, randomY] = 'E';
            }
        }
        public void SpawnEnemies()
        {
            FindPosEnemy();

            // Make sure that they spawn in the center of the room and centered to the console window
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Get the current console window width divided by 2
            int halfConsoleWidth = consoleWidth / 2;
            int halfConsoleHeight = consoleHeight / 2;

            // Get the current room width divided by 2
            int halfRoomWidth = Width / 2;
            int halfRoomHeight = Height / 2;

            int startX = halfConsoleWidth - halfRoomWidth;
            int startY = halfConsoleHeight - halfRoomHeight;

            // Loop through the 2d char array and print out the enemies accordingly
            for (int y = 0; y < Height; y++)
            {
                // Loop through the 2d char array
                for (int x = 0; x < Width; x++)
                {
                    // If the current position in the 2d char array is an enemy
                    if (Room != null && Room[x, y] == 'E')
                    {
                        // Set the current position in the 2d char array to the enemy char
                        Console.SetCursorPosition(startX + x, startY + y);
                        Console.Write(Room[x, y]);
                    }
                }
            }
        }
    }
}