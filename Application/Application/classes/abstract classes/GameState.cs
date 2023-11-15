using Application.interfaces;

namespace Application.classes.abstract_classes
{
    public abstract class GameState
    {
        protected Stack<GameState> gameStates;
        protected List<ICharacter> playerChars;

        // boolean to pop the stack
        protected bool end;
        
        protected GameState(Stack<GameState> gameStates, List<ICharacter> playerChars) {
            this.gameStates = gameStates;
            this.playerChars = playerChars;
        }

        public virtual void Update() {
            // Update GUI things in here
        }

        public bool RequestEnd() => end;
    }
}