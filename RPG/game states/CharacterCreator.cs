using RPG.characters;

namespace RPG.game_states
{
    public class CharacterCreator : GameState
    {
        public CharacterCreator(Stack<GameState> gameStates, List<Character> characters)
            : base(gameStates, characters)
        {
        }
    }
}