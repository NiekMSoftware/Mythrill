namespace RPG.game_states
{
    public abstract class GameState
    {
        // Stack of GameStates
        protected Stack<GameState> gameStates;

        // Protected boolean to check if the state is ending
        protected bool end;

        // Overloaded constructor with the game states
        protected GameState(Stack<GameState> gameStates)
        {
            // Set the protected field to the constructor
            // this will keep track of the state
            this.gameStates = gameStates;
        }

        // Is used to process input of the player
        public virtual void ProcessInput(int input){}

        // Protected method to update the game
        // Used for GUI related functionality
        public virtual void Update()
        {
        }

        // Public boolean to check if the state wants to end
        public bool RequestEnd() => end;
    }
}