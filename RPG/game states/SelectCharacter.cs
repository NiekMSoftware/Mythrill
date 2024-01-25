using System.Diagnostics;
using RPG.characters;
using RPG.game_states.endless;
using RPG.player_classes;
using RPG.user_interface;

namespace RPG.game_states
{
    public class SelectCharacter : GameState
    {
        private bool choseCharacter;

        public SelectCharacter(Stack<GameState> gameStates, List<Character> characters, 
                                List<Character> deadCharacters, bool selectedCombat) : 
            base(gameStates, characters, deadCharacters)
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
                    endState = true;
                    gameStates.Push(new CombatState(gameStates, characters, deadCharacters,
                    Selection(characters), true));
                }
                else
                {
                    endState = true;
                    Character playerChar = Selection(characters);
                    gameStates.Push(new EndlessState(gameStates, characters, deadCharacters,
                        playerChar, new Room(35, 12, playerChar)));
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

            while (selectedCharacter == null)
            {
                int input = Gui.GetInput("> ");

                if (input >= 1 && input <= charactersList.Count)
                {
                    selectedCharacter = charactersList[input - 1];
                    Debug.WriteLine($"Selected: {selectedCharacter.Name}");
                }
                else
                {
                    Console.WriteLine("Out of bounds! Please enter a valid option.");
                }
            }

            choseCharacter = true;
            return selectedCharacter;
        }
    }
}