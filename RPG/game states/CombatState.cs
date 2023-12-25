using System.Diagnostics;
using RPG.characters;
using RPG.characters.character_classes;
using RPG.interfaces;
using RPG.player_classes;

namespace RPG.game_states
{
    public class CombatState : GameState
    {
        public CombatState(Stack<GameState> gameStates, List<Character> characters) 
                            : base(gameStates, characters)
        {
            
        }

        public override void Update()
        {
            
        }

        private void InstantiateFight(Enemy enemy)
        {
            // TODO: Start the fight in a loop
        }
    }
}