using System.Diagnostics;
using Application.classes;
using Application.classes.abstract_classes;

namespace Application
{
    public class GameLoop
    {
        private Stack<GameState>? gameState;
        
        // Constructor to initialize needed states and/or other properties
        public GameLoop() {
            Debug.WriteLine("Created a new game loop!");
            InitState();       
        }

        private void InitState() {
            // Initialize a new state
            gameState = new Stack<GameState>();
            
            // Push out a new state
            gameState.Push(new MainMenu(gameState));
        }

        public void RunLoop() {
            // Keep the loop running as long there is a state
            while (gameState.Count > 0) {
                // Update the state stack
                gameState.Peek().Update();

                // If the game state wants to end, pop the stack
                if (gameState.Peek().RequestEnd())
                    gameState.Pop();
            }

            Console.WriteLine("Ending loop...");
            Debug.WriteLine("Ending Application!");
        }
    }
}