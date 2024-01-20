namespace RPG.game_states
{
    public class RoomGenerator
    {
        public enum Tile
        {
            Floor,
            InteriorWall,
            ExteriorWall,
            Entry,
            Exit
        }

        private Tile[,] tiles;

        // seed
        private int seed;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public int[] Start { get; private set; }
        public int[] Exit { get; private set; }

        // room sizes
        private int minRoomSize;
        private int maxRoomSize;

        // room count
        private int minRoomCount;
        private int maxRoomCount;

        public RoomGenerator(int seed, int width = 35, int height = 35, int minRoomCount = 7, int maxRoomCount = 9,
            int minRoomSize = 3, int maxRoomSize = 5)
        {
            this.seed = seed;
            Width = width;
            Height = height;
            this.minRoomSize = minRoomSize;
            this.maxRoomSize = maxRoomSize;
            this.minRoomCount = minRoomCount;
            this.maxRoomCount = maxRoomCount;

            // Set up tile grid with all walls
            FillInWalls();

            // Carve out rooms
            List<int[]> rooms = AddRooms();

            // Connect rooms, add doors
            AddCorridors(rooms);

            // Add the entry and exit tiles.
            AddEntryExit(rooms);

            // Make distiction for intertor and exterior walls.
            DetermineWallTypes();

            // Print out to console
            PrintRoom();
        }

        // gather tiles to not get out of bounds
        public Tile GetTileAt(int x, int y)
        {
            return tiles[x, y];
        }

        public void FillInWalls()
        {
            tiles = new Tile[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tiles[x, y] = Tile.ExteriorWall;
                }
            }
        }

        public List<int[]> AddRooms()
        {
            List<int[]> roomCenters = new List<int[]>();

            int roomCount = RandomRange(minRoomCount, maxRoomCount);
            for (int i = 0; i < roomCount; i++)
            {
                int x = RandomRange(maxRoomSize, Width - maxRoomSize);
                int y = RandomRange(maxRoomSize, Height - maxRoomSize);
                int w = RandomRange(minRoomSize, maxRoomSize);  // width
                int h = RandomRange(minRoomSize, maxRoomSize);  // height

                // carve room
                CarveOpen(x - (w / 2), y - (h / 2), w, h);
                roomCenters.Add(new int[2] { x, y });
            }

            return roomCenters;
        }

        public void AddCorridors(List<int[]> centers)
        {
            for (int i = 0; i < centers.Count - 1; i++)
            {
                // go from room to room, adding corridor between each
                // carve only accepts positive width, height so find the lower x/y cords and go higher.
                CarveOpen(Math.Min(centers[i][0], centers[i + 1][0]), centers[i][1],    // x / y
                    1 + Math.Abs(centers[i + 1][0] - centers[i][0]), 1);    // width / height

                CarveOpen(centers[i + 1][0], Math.Min(centers[i][1], centers[i + 1][1]),
                    1, 1 + Math.Abs(centers[i + 1][1] - centers[i][1]));
            }
        }

        public void AddEntryExit(List<int[]> centers)
        {
            int distHi = 0;
            int startIdx = -1;
            int endIdx = -1;

            // Pick the two rooms that are farthest away from each other. 
            for (int i = 0; i < centers.Count; ++i)
            {
                for (int j = 0; j < centers.Count; ++j)
                {
                    int dist = Math.Abs(centers[i][0] - centers[j][0]) + Math.Abs(centers[i][1] - centers[j][1]);

                    if (dist > distHi)
                    {
                        distHi = dist;
                        startIdx = i;
                        endIdx = j;
                    }
                }
            }

            Start = centers[startIdx];
            Exit = centers[endIdx];

            tiles[Start[0], Start[1]] = Tile.Entry;
            tiles[Exit[0], Exit[1]] = Tile.Exit;
        }

        public void DetermineWallTypes()
        {
            for (int x = 0; x < Width; ++x)
            {
                for (int y = 0; y < Height; ++y)
                {
                    if (tiles[x, y] != Tile.Floor)
                    {
                        continue;
                    }

                    for (int dx = -1; dx <= 1; ++dx)
                    {
                        for (int dy = -1; dy <= 1; ++dy)
                        {
                            // Check if the tile is within the grid
                            if (x + dx >= 0 && x + dx < Width && y + dy >= 0 && y + dy < Height)
                            {
                                // If there's an exterior wall, mark it as interior, instead.
                                if (tiles[x + dx, y + dy] == Tile.ExteriorWall)
                                {
                                    tiles[x + dx, y + dy] = Tile.InteriorWall;
                                }
                            }
                        }
                    }
                }
            }
        }

        public char TileToChar(Tile tile)
        {
            switch (tile)
            {
                case Tile.Floor:
                    return ' ';
                case Tile.InteriorWall:
                    return '#';
                case Tile.ExteriorWall:
                    return ' ';
                case Tile.Entry:
                    return '@'; 
                case Tile.Exit:
                    return 'E';
                default:
                    return ' ';
            }
        }

        public void PrintRoom()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(TileToChar(tiles[x, y]));
                }
                Console.WriteLine();
            }
        }

        // fill part of the map with "floor"
        private void CarveOpen(int x, int y, int width, int height)
        {
            if (width < 1 || height < 1)
            {
                return;
            }

            for (int dX = x; dX < x + width; dX++)
            {
                for (int dY = y; dY < y + height; dY++)
                {
                    tiles[dX, dY] = Tile.Floor;
                }
            }
        }

        // derive hashed value from int to get a random number
        private static int IntHas(ref int x)
        {
            if (x == 0)
            {
                x = 1;
            }
            x = ((x >> 16) ^ x) * 0x45d9f3b;
            x = ((x >> 16) ^ x) * 0x45d9f3b;
            x = (x >> 16) ^ x;
            return x;
        }

        // get random value from seed
        private int RandomRange(int min, int max)
        {
            int range = IntHas(ref seed) % ((max + 1) - min);
            return min + range;
        }
    }
}
