using RPG.characters;
using RPG.interfaces;

namespace RPG.player_classes
{
    public class Player : Character
    {
        public Player()
        {
            health = 10;
        }

        public static Player GetPlayer(Player player)
        {


            return player;
        }
    }
}