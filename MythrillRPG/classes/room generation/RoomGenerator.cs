namespace MythrillRPG.classes.room_generation
{
    public class RoomGenerator
    {
        public const int MaxX = 100;
        public const int MaxY = 100;
        
        public const int RoomMaxWidth = 22;
        public const int RoomMaxHeight = 22;
        public const int RoomMaxAmount = 8;

        public const int GridSize = 200;
        
        public const char EmptySpace = ' ';
        public const char Wall = '#';
        public const char Hallway = '.';
        
        private Random random = new Random();

        // Generate the room
        public Room GenerateRoom(int maxWidth, int maxHeight, int maxX, int maxY)
        {
            // Save the new width, height, x and y to new variables and return a new Room
            var width = random.Next(maxWidth / 2, maxWidth);
            var height = random.Next(maxHeight / 2, maxHeight);
            var x = random.Next(0, maxX - width);
            var y = random.Next(0, maxY - height);

            return new Room(width, height, x, y);
        }

        private bool DoesRoomIntersect(Room newRoom, List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                if (RoomsIntersect(newRoom, room))
                {
                    return true;
                }
            }

            return false;
        }

        // Create a new public List Method of the Rooms to generate it 
        public List<Room> GenerateRooms(int numbOfRooms, int maxWidth, int maxHeight, int maxX, int maxY)
        {
            // Initialize the list of rooms
            List<Room> rooms = new List<Room>();

            // Loop to generate the specified number of rooms
            for (int i = 0; i < numbOfRooms; i++)
            {
                Room newRoom;

                // Keep generating rooms until we get one that doesn't intersect with any existing room
                do
                {
                    // Generate a new room
                    newRoom = GenerateRoom(maxWidth, maxHeight, maxX, maxY);
                } while (DoesRoomIntersect(newRoom, rooms)); // If the room intersects, generate a new one
                // If the room doesn't intersect with any existing room, add it to the list
                rooms.Add(newRoom);
            }
            return rooms;
        }

        // Method to check if two rooms intersect
        private bool RoomsIntersect(Room room1, Room room2)
        {
            // If one room is to the right of the other, or one room is above the other, then they don't intersect
            // If neither of these conditions is true, then the rooms intersect
            return room1.X < room2.X + room2.Width &&
                   room1.X + room1.Width > room2.X &&
                   room1.Y < room2.Y + room2.Height &&
                   room1.Y + room1.Height > room2.Y;
        }


        public void InitializeRoom()
        {
            RoomGenerator generator = new RoomGenerator();

            // Add a new list of hallways
            List<Hallway> hallways = new List<Hallway>();
            
            // Create a new list of the Room and generate it
            List<Room> rooms = generator.GenerateRooms(RoomMaxAmount, RoomMaxWidth, RoomMaxHeight, MaxX, MaxY);

            // Create hallway objects
            for (int i = 0; i < rooms.Count - 1; i++)
            {
                hallways.Add(new Hallway(rooms[i], rooms[i + 1]));
            }
            
            // Create a new grid
            char[,] grid = new char[GridSize, GridSize];

            // Initialize the grid with empty spaces
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    grid[i, j] = EmptySpace;
                }
            }

            // Carve out the rooms
            foreach (var room in rooms)
            {
                for (int i = room.X; i < Math.Min(room.X + room.Width, grid.GetLength(0)); i++)
                {
                    for (int j = room.Y; j < Math.Min(room.Y + room.Height, grid.GetLength(1)); j++)
                    {
                        // carve out the room
                        grid[i, j] = Hallway;
                        // Add walls around the room
                        if (i == room.X || i == room.X + room.Width - 1
                                        || j == room.Y || j == room.Y + room.Height - 1)
                        {
                            grid[i, j] = Wall;
                        }
                    }
                }
            }

            // Connect the rooms
            for (int i = 0; i < hallways.Count; i++)
            {
                var hallway = hallways[i];
                var path = hallway.GetPath();

                foreach (var (x,y) in path)
                {
                    if (x < grid.GetLength(0) && y < grid.GetLength(1))
                    {
                        // place hallway
                        grid[x, y] = Hallway;
                        
                        // place wall next to the hallway
                        if (x > 0 && grid[x-1, y] == EmptySpace) grid[x-1, y] = Wall;
                        if (y > 0 && grid[x, y-1] == EmptySpace) grid[x, y-1] = Wall;
                        if (x < grid.GetLength(0) - 1 && grid[x+1, y] == EmptySpace) grid[x+1, y] = Wall;
                        if (y < grid.GetLength(1) - 1 && grid[x, y+1] == EmptySpace) grid[x, y+1] = Wall;
                    }
                }
            }

            // Print out the grid
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.Write(grid[i, j]);
                }

                // Empty line
                Console.WriteLine();
            }
        }
    }
}