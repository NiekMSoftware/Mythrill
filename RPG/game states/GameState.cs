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
        protected bool endState;

        // Protected boolean to check if the combat has ended
        protected bool endCombat;

        // Constant int to keep the capacity up, this property is on private
        private const int LIST_SIZE = 10;

        /// <summary>
        /// Overloaded Constructor, make sure to keep in the parameters
        /// </summary>
        /// <param name="gameStates"></param>
        /// <param name="characters"></param>
        protected GameState(Stack<GameState> gameStates, List<Character> characters)
        {
            // Set the protected field to the constructor
            // this will keep track of the state
            this.gameStates = gameStates;
            this.characters = characters;

            this.characters = new List<Character>(LIST_SIZE);  // initialize the list to 10
        }

        /// <summary>
        /// ProcessInput is used to process all regarding input within a switch statement
        /// </summary>
        /// <param name="input"></param>
        public virtual void ProcessInput(int input) { }
        public virtual void ProcessInput(int input, Character playerCharacter) { }

        /// <summary>
        /// Update function to generate any GUI output
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Returns the boolean 'endState' either true or false
        /// </summary>
        /// <returns></returns>
        public bool RequestEnd() => endState;
    }
}