using RPG.game_states;

namespace RPG
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var game = new Game();
            //game.RunLoop();

            Random random = new Random();
            int seed = random.Next(int.MinValue, int.MaxValue);

            RoomGenerator generator = new RoomGenerator(seed, 70, 70, 4, 12, 4, 5);

            // Now you can use the generator's methods to interact with the generated rooms
            // For example, you can get the tile at a specific location
            RoomGenerator.Tile tile = generator.GetTileAt(10, 10);
            Console.WriteLine($"Tile at (10, 10) is: {tile}");

            // Or get the start and exit points
            int[] start = generator.Start;
            int[] exit = generator.Exit;
            Console.WriteLine($"Start is at ({start[0]}, {start[1]})");
            Console.WriteLine($"Exit is at ({exit[0]}, {exit[1]})");
        }
    }
}