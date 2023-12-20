using System.Diagnostics;
using RPG.game_states;

namespace RPG
{
    public class Game
    {
        // Create a stack from the GameState class
        private Stack<GameState>? currentState;

        // initialize variables in constructor
        public Game()
        {
            InitializeStates();
        }

        // Method to initialize concurrent states
        private void InitializeStates()
        {
            // Initialize currentState
            currentState = new Stack<GameState>();

            // Push through a new Stack
            currentState.Push(new MainMenu(currentState));
        }

        public void RunLoop()
        {
            do
            {
                if (currentState == null)
                {
                    Debug.WriteLine($"No {currentState} has been found.");
                    break;
                }

                // Update the Game
                currentState.Peek().Update();

                // Check if the stack wants to end
                if (currentState.Peek().RequestEnd())
                {
                    // Pop the state
                    currentState.Pop();
                }
            } while(currentState.Count > 0);
        }
    }
}

