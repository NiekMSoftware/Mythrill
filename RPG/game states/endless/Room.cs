using System.Diagnostics;
using RPG.characters;
using RPG.player_classes;

namespace RPG.game_states.endless;

public class Room
{
    public int Width { get; set; }
    public int Height { get; set; }

    public char[,] RoomData { get; set; }
    public char[,] OriginalRoomData { get; set; }

    public bool CollisionEnemy = false;

    // Room gen
    private const char WALL = '#';
    private const char FLOOR = ' ';
    private const char ENEMY = 'E';

    // ref to playerController
    PlayerController playerController;
    private Character? player;

    // random
    private static Random rng = new Random();
    
    // list to keep track of enemies
    public List<Enemy> Enemies = new List<Enemy>();
    
    public Room(int width, int height, Character? selectedCharacter)
    {
        // clear out console
        Console.Clear();

        Width = width;
        Height = height;
        
        // init player controller
        playerController = new() { X = Width / 2, Y = Height / 2 };
        player = selectedCharacter;
        
        // init room
        CreateRoom();
        GenerateRoom();
        PrintRoom();
        
        // create a copy of the room
        OriginalRoomData = (char[,])RoomData.Clone();
    }

    public void SpawnEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int x = rng.Next(1, Width - 1);
            int y = rng.Next(1, Height - 1);
            
            // Check if the position is valid and not occupied by the player
            if (IsPositionValid(x, y) && (x != playerController.X || y != playerController.Y))
            {
                Enemy enemy = new Enemy(player);
                enemy.X = x;
                enemy.Y = y;
                Enemies.Add(enemy);
                RoomData[x, y] = ENEMY;
            }
        }
    }
    
    private void CreateRoom()
    {
        RoomData = new char[Width, Height];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                RoomData[x, y] = WALL;
            }
        }
    }

    private void GenerateRoom()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                // check for the edges of the room and replace them with walls
                if (y == 0 || y == Height - 1 || x == 0 || x == Width - 1)
                {
                    RoomData[x, y] = WALL;
                }
                else
                {
                    // else fill the room with floors
                    RoomData[x, y] = FLOOR;
                }
            }
        }

        // generate a position for the player to spawn in at
        int centerX = Width / 2;
        int centerY = Height / 2;
        int numbOfEnemies = rng.Next(1, 4);

        RoomData[centerX, centerY] = PlayerController.PlayerChar;
        
        SpawnEnemies(numbOfEnemies);
    }

    public void PrintRoom()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Console.Write(RoomData[x, y]);
            }
            // empty lines
            Console.WriteLine();
        }
    }

    public void UpdateRoom()
    {
        CollisionEnemy = false;
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            if (playerController.Movement.ContainsKey(key))
            {
                var (dx, dy) = playerController.Movement[key];
                int newX = playerController.X + dx;
                int newY = playerController.Y + dy;

                // Check if the new position is within the room and not a wall
                if (IsPositionValid(playerController.X + dx, playerController.Y + dy))
                {
                    if (IsEnemyAtPosition(newX, newY))
                    {
                        HandleEnemyCollision(newX, newY);
                    }
                    
                    // Remove player from old position
                    Console.SetCursorPosition(playerController.X, playerController.Y);
                    Console.Write(FLOOR);

                    // Update player position
                    playerController.X = newX;
                    playerController.Y = newY;

                    // Place player at new position
                    Console.SetCursorPosition(playerController.X, playerController.Y);
                    Console.Write(PlayerController.PlayerChar);
                    
                    // Remove player from old position in OriginalRoomData
                    OriginalRoomData[playerController.X - dx, playerController.Y - dy] = FLOOR; 

                    // Update player position in OriginalRoomData
                    OriginalRoomData[playerController.X, playerController.Y] = PlayerController.PlayerChar;
                }
            }
            else
            {
                Console.WriteLine("Invalid key!");
                Debug.WriteLine("Invalid key!");
            }
        }
    }

    public void PrintOriginalRoom()
    {
        Debug.WriteLine($"Array Dimensions: {OriginalRoomData.GetLength(0)}, {OriginalRoomData.GetLength(1)}");

        for (int j = 0; j < OriginalRoomData.GetLength(1); j++)
        {
            for (int i = 0; i < OriginalRoomData.GetLength(0); i++)
            {
                Console.Write(OriginalRoomData[i, j]);
            }
            Console.WriteLine();
        }
    }

    private void HandleEnemyCollision(int enemyX, int enemyY)
    {
        RoomData[enemyX, enemyY] = FLOOR;
        Enemies.RemoveAll(e => e.X == enemyX && e.Y == enemyY);

        CollisionEnemy = true;
    }
    
    private bool IsPositionValid(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height && RoomData[x, y] != WALL;
    }

    private bool IsEnemyAtPosition(int x, int y) => RoomData[x, y] == ENEMY;
}