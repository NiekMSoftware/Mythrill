namespace MythrillRPG.classes.room_generation
{
    public class Hallway
    {
        public Room StartRoom { get; }
        public Room EndRoom { get; }

        public Hallway(Room startRoom, Room endRoom)
        {
            StartRoom = startRoom;
            EndRoom = endRoom;
        }

        public List<(int X, int Y)> GetPath()
        {
            var path = new List<(int X, int Y)>();
            
            // We start from the center of StartRoom
            int startX = StartRoom.X + StartRoom.Width / 2;
            int startY = StartRoom.Y + StartRoom.Height / 2;
            
            // We end at the center of EndRoom
            int endX = EndRoom.X + EndRoom.Width / 2;
            int endY = EndRoom.Y + EndRoom.Height / 2;
            
            // We first draw a line at the X-axis
            for (int x = startX; x != endX; x += Math.Sign(endX - startX))
            {
                path.Add((x, startY));
            }
            
            // afterwards we do it with the y-axis
            for (int y = startY; y != endY; y += Math.Sign(endY - startY))
            {
                path.Add((endX, y));
            }

            return path;
        }
    }
}