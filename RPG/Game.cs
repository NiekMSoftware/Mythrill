using System.Diagnostics;
using RPG.characters;
using RPG.game_states;

namespace RPG
{
    public class Game
    {
        // Create a stack from the GameState class
        private Stack<GameState>? currentState;
        
        // Create an ArrayList of the characters
        private List<Character>? playerCharacters;

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

            // Initialize playerCharacters
            playerCharacters = new List<Character>();

            // Push through a new Stack
            currentState.Push(new MainMenu(currentState, playerCharacters));
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

            Console.WriteLine("\n\nThank you for playing!");
        }
    }
}

