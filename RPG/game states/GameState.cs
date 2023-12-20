using System.Collections;
using RPG.characters;

namespace RPG.game_states
{
    public abstract class GameState
    {
        // Stack of GameStates
        protected Stack<GameState> gameStates;

        // ArrayList of CreatedCharacters
        protected List<Character> characters;
        public List<Character> Characters
        {
            get => characters;
            set => characters = value;
        }

        // Protected boolean to check if the state is ending
        protected bool end;

        // Overloaded constructor with the game states
        protected GameState(Stack<GameState> gameStates, List<Character> characters)
        {
            // Set the protected field to the constructor
            // this will keep track of the state
            this.gameStates = gameStates;
            this.characters = characters;
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