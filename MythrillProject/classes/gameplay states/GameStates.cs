namespace MythrillProject.classes.gameplay_states
{
    public abstract class GameStates
    {
        protected Stack<GameStates> gameStates;
        protected bool end;

        protected GameStates(Stack<GameStates> gameStates) {
            this.gameStates = gameStates;
        }

        public virtual void Update() {
            
        }

        public bool RequestEnd() => end;
    }
}