namespace Application
{
    internal class Program
    {
        private static void Main(string[] args) {
            // Initialize a new game object and run the program
            var loop = new GameLoop();
            loop.RunLoop();
        }
    }
}