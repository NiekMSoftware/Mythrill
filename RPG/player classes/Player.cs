using System.Diagnostics;
using RPG.characters;
using RPG.game_states;
using RPG.interfaces;

namespace RPG.player_classes
{
    public class Player : Character
    {
        public static Character? GetPlayer(Character? player)
        {
            Debug.WriteLine($"Returning {player}\n" +
                            $"Player's Name is : {player.Name}");
            return player;
        }
    }
}