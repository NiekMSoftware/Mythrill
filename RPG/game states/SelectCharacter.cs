using System.Diagnostics;
using RPG.characters;
using RPG.user_interface;

namespace RPG.game_states
{
    public class SelectCharacter : GameState
    {
        private bool choseCharacter;

        public SelectCharacter(Stack<GameState> gameStates, List<Character> characters, bool selectedCombat) : 
            base(gameStates, characters)
        {
            this.selectedCombat = selectedCombat;
            this.characters = characters;
        }

        public override void Update()
        {
            Gui.GameState("Select Character");
            if (!choseCharacter)
            {
                if (selectedCombat)
                {
                    Debug.WriteLine("Pushing in Combat");
                    gameStates.Push(new CombatState(gameStates, characters, Selection(characters)));
                }
                else
                {
                    Debug.WriteLine("Pushing in Endless Mode");
                    gameStates.Push(new EndlessState(gameStates, characters, Selection(characters)));
                }
            }
            
        }

        public Character? Selection(List<Character> charactersList)
        {
            Character? selectedCharacter = null;

            for (int i = 0; i < charactersList.Count; i++)
            {
                Gui.ShowOptions(i + 1, $"{charactersList[i].Name}");
            }

            int input = Gui.GetInput("> ");

            if (input >= 1 && input <= charactersList.Count)
            {
                selectedCharacter = charactersList[input - 1];
                Debug.WriteLine($"Selected: {selectedCharacter.Name}");
            }
            else
            {
                Console.WriteLine("Out of bounds!");
            }

            choseCharacter = true;
            return selectedCharacter ?? null;
        }
    }
}