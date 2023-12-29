using System.Diagnostics;
using RPG.characters;
using RPG.characters.character_classes;
using RPG.interfaces;

namespace RPG
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var game = new Game();
            //game.RunLoop();

            // call the RoomGenerator constructor and pass in the width and height
            RoomGenerator roomGenerator = new(40, 15);

            PlayerMovement movement = new();
            movement.Start();
        }
    }
}