using RPG.characters;

namespace RPG.interfaces;

public interface ICombatStrategy
{
    void Execute(Character player, Character enemy, bool playerSuccess, bool enemySuccess);
}