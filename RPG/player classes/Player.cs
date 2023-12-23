using RPG.characters;
using RPG.interfaces;

namespace RPG.player_classes
{
    public class Player : Character, IPlayer
    {
        public void ProcessCombatInput(int input, Character player)
        {
            switch (input)
            {
                case 0:
                    player.Attack();
                    break;
                case 1:
                    player.Defend();
                    break;
                case 2:
                    player.Heal();
                    break;
            }
        }
    }
}