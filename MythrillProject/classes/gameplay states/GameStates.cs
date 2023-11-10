using MythrillProject.classes.custom_character;

namespace MythrillProject.classes.gameplay_states
{
    public abstract class GameStates
    {
        protected Stack<GameStates> gameStates;
        protected List<PlayerCharacter> playerCharacters;
        protected bool end;

        protected GameStates(Stack<GameStates> gameStates, List<PlayerCharacter> playerCharacters) {
            this.gameStates = gameStates;
            this.playerCharacters = playerCharacters;
        }

        public virtual void Update() {
            
        }

        public virtual void ProcessInput(int input) {
            
        }

        public bool RequestEnd() => end;
    }
}