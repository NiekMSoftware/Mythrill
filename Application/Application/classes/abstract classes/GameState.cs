namespace Application.classes.abstract_classes
{
    public abstract class GameState
    {
        private Stack<GameState> gameStates;

        // boolean to pop the stack
        protected bool end;
        
        protected GameState(Stack<GameState> gameStates) {
            this.gameStates = gameStates;
        }

        public virtual void Update() {
            // Update GUI things in here
        }

        public bool RequestEnd() => end;
    }
}