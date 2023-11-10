using MythrillProject.classes.custom_character;
using MythrillProject.classes.gameplay_states;

namespace MythrillProject
{
    public class Game
    {
        private Stack<GameStates> gameState;
        private List<PlayerCharacter> playerCharacters;
        
        // constructor to initialize data
        public Game() {
            InitState();
            InitWindow();
        }

        private void InitState() {
            gameState = new Stack<GameStates>();
            playerCharacters = new List<PlayerCharacter>();
            
            gameState.Push(new MainMenu(gameState, playerCharacters));
        }

        private void InitWindow() {
            Console.Title = "Mythrill";
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

            Console.WriteLine("Ending Application...");
        }
    }
}