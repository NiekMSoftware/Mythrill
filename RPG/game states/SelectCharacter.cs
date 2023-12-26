using System.Diagnostics;
using RPG.characters;

namespace RPG.game_states
{
    public class SelectCharacter : GameState
    {
        public SelectCharacter(Stack<GameState> gameStates, List<Character> characters) : 
            base(gameStates, characters)
        {
            this.characters = characters;
        }

        public override void Update()
        {
            Gui.GameState("Select your Character");

            gameStates.Push(new CombatState(gameStates, characters, Selection(characters)));
            endState = true;
        }

        public static Character Selection(List<Character> characters)
        {
            Character selectedCharacter = null;

            for (int i = 0; i < characters.Count; i++)
            {
                Gui.ShowOptions(i + 1, $"{characters[i].Name}");
            }

            int input = Gui.GetInput("> ");

            if (input >= 1 && input <= characters.Count)
            {
                selectedCharacter = characters[input - 1];
                Debug.WriteLine($"Selected: {selectedCharacter.Name}");
            }
            else
            {
                Console.WriteLine("Out of bounds!");
            }

            return selectedCharacter;
        }
    }
}