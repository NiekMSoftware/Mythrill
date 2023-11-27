using MythrillRPG.classes.room_generation;

namespace MythrillRPG
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Initialize a new game object and run the game
            //Game game = new Game();
            //game.RunGame();

            RoomGenerator generator = new RoomGenerator();
            generator.InitializeRoom();
            Console.SetWindowSize(101, 101);

            Console.ReadKey();
        }
    }
}