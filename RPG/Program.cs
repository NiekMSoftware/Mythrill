using RPG.characters;
using RPG.characters.character_classes;
using RPG.interfaces;

namespace RPG
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game();
            game.RunLoop();
        }
    }
}