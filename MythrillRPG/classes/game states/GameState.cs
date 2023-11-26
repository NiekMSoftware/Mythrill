namespace MythrillRPG.classes.game_states
{
    /* GameState abstract class needs to be the following:
     * - Able ProcessInput
     * - Constructor to keep track of which state the user is in
     * - Public virtual Update function, reason on
     *   virtual is to override it
     * - Public RequestEnd function that automatically returns
     *   protected boolean 'end'.
     */

    public abstract class GameState
    {
        // Only be able to be gathered from inherited classes
        protected Stack<GameState> gameStates;

        // Protected boolean field to end stack/state
        protected bool endState;

        // Constructor to initialize the new state
        protected GameState(Stack<GameState> gameStates)
        {
            this.gameStates = gameStates;
        } 

        // Run all GUI stuff in here!
        public virtual void Update() { }

        // Switch the parameter value
        public virtual void ProcessInput(int input) { }

        // Request to End the stack
        public bool RequestEnd() => endState;
    }
}