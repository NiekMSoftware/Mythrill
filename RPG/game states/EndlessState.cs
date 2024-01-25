using System.Diagnostics;
using RPG.characters;
using RPG.game_states.endless;
using RPG.player_classes;

namespace RPG.game_states
{
    public class EndlessState : GameState
    {
        private Character playerCharacter;

        public EndlessState(Stack<GameState> gameStates, List<Character> characters, List<Character> deCharacters,
            Character? playerChar, Room room) 
            : base(gameStates, characters, deCharacters)
        {
            if (playerChar != null)
            {
                playerCharacter = playerChar;
            }
        }

        public override void Update()
        {
            // make sure the terminal is not buffering after the player moves
            Console.CursorVisible = false;
        }
    }
}