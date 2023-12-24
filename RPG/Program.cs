using RPG.characters;
using RPG.characters.character_classes;
using RPG.interfaces;
using Type = RPG.characters.Type;

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