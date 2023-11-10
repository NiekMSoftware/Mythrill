using MythrillProject.classes.gameplay_states;

namespace MythrillProject
{
    public class Game
    {
        private Stack<GameStates> gameState;
        
        // constructor to initialize data
        public Game() {
            InitState();
        }

        private void InitState() {
            gameState = new Stack<GameStates>();
            
            gameState.Push(new MainMenu(gameState));
        }
        
        public void RunGame() {
            // Create a while loop based on the count of the Stack
            while (gameState.Count > 0) {
                // Update the game
                gameState.Peek().Update();
                
                // Check if the state wants to end
                if (gameState.Peek().RequestEnd()) {
                    gameState.Pop();
                }
            }
        }
    }
}