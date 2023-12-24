using RPG.characters;
using RPG.interfaces;

namespace RPG.player_classes
{
    public class Player : Character, IPlayer
    {
        public Player()
        {
            health = 10;
        }
    }
}