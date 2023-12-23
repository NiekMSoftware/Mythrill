using RPG.characters;

namespace RPG.interfaces
{
    public interface IPlayer
    {
        public void ProcessCombatInput(int input, Character player);
    }
}