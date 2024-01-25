using System.Diagnostics;
using RPG.characters;
using RPG.user_interface;

namespace RPG.game_states
{
    public class MainMenu : GameState
    {
        public MainMenu(Stack<GameState> gameStates, List<Character> characters, List<Character> deadCharacters) 
            : base(gameStates, characters, deadCharacters)
        {
            
        }

        public override void Update()
        {
            Console.Clear();
            Gui.GameTitle("Mythrill");
            Gui.GameState("Main Menu");

            Gui.ShowOptions(1, "Play Game");
            Gui.ShowOptions(2, "Character Creator");
            Gui.ShowOptions(3, "Credits");
            Gui.ShowOptions(-1, "Exit");

            ProcessInput(Gui.GetInput("> "));
        }

        public override void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    CheckCharacters();
                    break;

                case 2:
                    Console.Clear();
                    gameStates.Push(new CharacterCreator(gameStates, characters, deadCharacters));
                    break;

                case 3:
                    Console.WriteLine("Displaying Options");
                    break;

                case -1:
                    endState = true;
                    break;

                default:
                    Console.Write($"Index: {input} is out of bounds.\n" +
                                  $"Please enter a valid index!\n");
                    break;
            }
        }

        private void SelectMode()
        {
            Gui.GameState("Select a Mode");
            Gui.ShowOptions(1, "Combat Mode");
            Gui.ShowOptions(2, "Endless Mode");

            // Make sure the player stays in the loop until they select a valid index
            while (true)
            {
                ProcessSelection(Gui.GetInput("> "));

                // if the player has selected a valid index, break out of the loop
                if (gameStates.Count > 1)
                {
                    break;
                }
            }
        }

        private void ProcessSelection(int input)
        {
            switch (input)
            {
                case 1:
                    Console.Clear();
                    selectedCombat = true;
                    gameStates.Push(new SelectCharacter(gameStates, characters, deadCharacters,selectedCombat));
                    break;
                case 2:
                    Console.Clear();
                    gameStates.Push(new SelectCharacter(gameStates, characters, deadCharacters, selectedCombat));
                    break;
                default:
                    Console.Write($"Input {input} is a invalid index!\n" +
                                  "Please enter a valid index!\n");
                    break;
            }
        }

        private void CheckCharacters()
        {
            if (characters.Count == 0)
            {
                Console.WriteLine("You don't have any characters yet.\n" +
                                  "(press any key to continue)");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                // check if the first character is alive
                if (!characters[0].IsAlive())
                {
                    Debug.WriteLine($"{characters[0].Name} has died! Adding to the deadCharacters list...\n");

                    // if false remove it from the list and add it to the deadCharacters list
                    RemoveFromList(characters[0]);

                    // debug
                    foreach (var deadCharacter in deadCharacters)
                    {
                        Debug.WriteLine($"Currently in list: {deadCharacter.Name}");
                    }
                }

                // if there are still characters left, continue
                if (characters.Count > 0)
                {
                    // check if the others have died as well
                    foreach (var character in characters)
                    {
                        if (!character.IsAlive())
                        {
                            RemoveFromList(character);
                            break;
                        }
                    }
                    Console.Clear();
                    SelectMode();
                }
                else
                {
                    Console.WriteLine("All characters have died!\n" +
                                      "(press any key to continue)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void RemoveFromList(Character character)
        {
            deadCharacters.Add(character);
            characters.RemoveAt(0);
        }
    }
}