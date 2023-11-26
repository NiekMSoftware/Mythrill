using MythrillRPG.classes.game_states;

namespace MythrillRPG
{
    /* What the game will need to run:
     * - Stack of GameStates
     * - Constructor
     * - private method to Initialize the first state
     * - A loop to keep the game running as long as there are stacks
     */

    public class Game
    {
        // Stack of GameState
        private Stack<GameState>? currentState;

        // Constructor
        public Game()
        {
            Init();
        }

        // Method to initialize the stack and push in a fresh one
        // at initialization!
        private void Init()
        {
            // Initialize the currentState property
            currentState = new Stack<GameState>();

            // Push out the MainMenu stack
            currentState.Push(new MainMenu(currentState));
        }

        public void RunGame()
        {
            // Check for a null-reference
            if (currentState == null) return;

            // Run a loop while there is a stack
            while (currentState.Count > 0)
            {
                // While that is the case, update the stack
                currentState.Peek().Update();

                // Check if the current state wants to end
                if (currentState.Peek().RequestEnd())
                    currentState.Pop();
            }

            // Display a message to let the player know it has ended
            Console.WriteLine("Exiting application...");
        }
    }
}
