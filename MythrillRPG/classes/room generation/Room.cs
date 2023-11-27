namespace MythrillRPG.classes.room_generation
{
    public class Room
    {
        // Properties to define the room
        public int Width { get; set; }
        public int Height { get; set; }
        
        public int X { get; set; }
        public int Y { get; set; }

        // Constructor to set properties' value
        public Room(int width, int height, int x, int y)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }
    }

    public class RoomGenerator
    {
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

        // Create a new public List Method of the Rooms to generate it 
        public List<Room> GenerateRooms(int numbOfRooms, int maxWidth, int maxHeight, int maxX, int maxY)
        {
            // Initialize the list of rooms
            List<Room> rooms = new List<Room>();

            // Loop to generate the specified number of rooms
            for (int i = 0; i < numbOfRooms; i++)
            {
                Room newRoom;
                bool roomIntersects;

                // Keep generating rooms until we get one that doesn't intersect with any existing room
                do
                {
                    // Generate a new room
                    newRoom = GenerateRoom(maxWidth, maxHeight, maxX, maxY);
                    roomIntersects = false;

                    // Check the new room against all existing rooms for intersection
                    foreach (var room in rooms)
                    {
                        if (RoomsIntersect(newRoom, room))
                        {
                            // If the new room intersects with an existing room, set the flag to true
                            roomIntersects = true;
                            break;
                        }
                    }
                } while (roomIntersects); // If the room intersects, generate a new one
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
            int maxX = 75;
            int maxY = 75;

            RoomGenerator generator = new RoomGenerator();

            // Create a new list of the Room and generate it
            List<Room> rooms = generator.GenerateRooms(5, 15, 15, maxX, maxY);

            // Create a new grid
            char[,] grid = new char[100, 100];

            // Initialize the grid with walls
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    grid[i, j] = ' ';
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
                        grid[i, j] = '.';
                        // Add walls around the room
                        if (i == room.X || i == room.X + room.Width - 1
                                        || j == room.Y || j == room.Y + room.Height - 1)
                        {
                            grid[i, j] = '#';
                        }
                    }
                }
            }

            // Connect the rooms
            for (int i = 0; i < rooms.Count - 1; i++)
            {
                Room room1 = rooms[i];
                Room room2 = rooms[i + 1];

                // Find the center of the room
                int x1 = room1.X + room1.Width / 2;
                int y1 = room1.Y + room1.Height / 2;
                int x2 = room2.X + room2.Width / 2;
                int y2 = room2.Y + room2.Height / 2;

                // Draw the hallway between the rooms
                for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                {
                    if (x < grid.GetLength(0) && y1 < grid.GetLength(1))
                    {
                        grid[x, y1] = '.';
                    }
                }
                for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                {
                    if (x2 < grid.GetLength(0) && y < grid.GetLength(1))
                    {
                        grid[x2, y] = '.';
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
