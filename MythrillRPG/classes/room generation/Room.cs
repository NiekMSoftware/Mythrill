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
}
