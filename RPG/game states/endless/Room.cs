using RPG.player_classes;

namespace RPG.game_states.endless;

public class Room
{
    public int Width { get; set; }
    public int Height { get; set; }

    public char[,] RoomData { get; set; }

    // Room gen
    private const char WALL = '#';
    private const char FLOOR = ' ';

    // ref to playerController
    PlayerController playerController;

    public Room(int width, int height)
    {
        // clear out console
        Console.Clear();

        Width = width;
        Height = height;

        // init room
        CreateRoom();
        GenerateRoom();
        PrintRoom();

        // init player
        playerController = new();
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

        RoomData[centerX, centerY] = PlayerController.PlayerChar;
    }

    private void PrintRoom()
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

    }
}