using System.Diagnostics;
using RPG.characters;
using RPG.user_interface;

namespace RPG.game_states
{
    public class SelectCharacter : GameState
    {
        private bool choseCharacter;

        public SelectCharacter(Stack<GameState> gameStates, List<Character> characters) : 
            base(gameStates, characters)
        {
            this.characters = characters;
        }

        public override void Update()
        {
            if (!choseCharacter)
            {
                gameStates.Push(new CombatState(gameStates, characters, 
                    Selection(characters)));
            }
            else
            {
                endState = true;
                Debug.WriteLine($"Popped {this}");
            }
        }

        public Character Selection(List<Character> characters)
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

            choseCharacter = true;
            return selectedCharacter;
        }
    }
}