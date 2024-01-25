using System.Diagnostics;
using RPG.characters;
using RPG.game_states.endless;
using RPG.player_classes;

namespace RPG.game_states
{
    public class EndlessState : GameState
    {
        private Character playerCharacter;

        private Room room;

        public EndlessState(Stack<GameState> gameStates, List<Character> characters, List<Character> deadCharacters,
            Character? playerChar, Room room) 
            : base(gameStates, characters, deadCharacters)
        {
            this.room = room;

            if (playerChar != null)
            {
                playerCharacter = playerChar;
            }
        }

        public override void Update()
        {
            // make sure the terminal is not buffering after the player moves
            Console.CursorVisible = false;

            // update the room each frame
            room.UpdateRoom();
        }
    }
}