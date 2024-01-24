using System.Diagnostics;
using RPG.characters;
using RPG.game_states.endless;
using RPG.player_classes;

namespace RPG.game_states
{
    public class EndlessState : GameState
    {
        public Room Room { get; set; }

        private Character playerCharacter;
        private PlayerController playerController;

        public EndlessState(Stack<GameState> gameStates, List<Character> characters, Character? playerChar) 
            : base(gameStates, characters)
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

            // get the player's input
            var key = Console.ReadKey(true).Key;
        }
    }
}