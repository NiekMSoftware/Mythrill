using RPG.characters;

namespace RPG.game_states.endless;

public class Room
{
    public Character? Player { get; set; }

    public int Width { get; private set; }
    public int Height { get; private set; }

    public char[,] room { get; private set; }

    private const char WALL = '#';
    private const char FLOOR = ' ';

    public Room(Character? player, int width, int height)
    {
        Height = height;
        Width = width;
        Player = player;

        Console.Clear();
        GenerateRoom();
        PrintRoom();
    }

    private void GenerateRoom()
    {
        room = new char[Height, Width];

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (i == 0 || i == Height - 1 || j == 0 || j == Width - 1)
                {
                    room[i, j] = WALL;
                }
                else
                {
                    room[i, j] = FLOOR;
                }
            }
        }
    }

    private void PrintRoom()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                Console.Write(room[i, j]);
            }
            Console.WriteLine();
        }
    }
}