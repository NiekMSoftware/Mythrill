using System.Diagnostics;
using RPG.characters;
using RPG.game_states.endless;

namespace RPG.game_states
{
    public class EndlessState : GameState
    {
        public Room Room { get; set; }

        private Character playerCharacter;

        public EndlessState(Stack<GameState> gameStates, List<Character> characters, Character? playerChar) 
            : base(gameStates, characters)
        {
            playerCharacter = playerChar;
            Room = new Room(playerChar, 40, 20);
        }

        public override void Update()
        {
            
        }
    }
}