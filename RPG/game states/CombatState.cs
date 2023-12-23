using RPG.characters;

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

        private void InstantiateFight()
        {
            Enemy enemyAI = new Enemy();
        }
    }
}