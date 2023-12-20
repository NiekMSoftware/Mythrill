﻿using System.Collections;
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
        }

        /// <summary>
        /// ProcessInput is used to process all regarding input within a switch statement
        /// </summary>
        /// <param name="input"></param>
        public virtual void ProcessInput(int input){}

        /// <summary>
        /// Update function to generate any GUI output
        /// </summary>
        public virtual void Update()
        {
        }

        /// <summary>
        /// Returns the boolean 'end' either true or false
        /// </summary>
        /// <returns></returns>
        public bool RequestEnd() => end;
    }
}