using System.Diagnostics;
using RPG.characters;
using RPG.user_interface;

namespace RPG.game_states
{
    public class MainMenu : GameState
    {
        public MainMenu(Stack<GameState> gameStates, List<Character> characters) 
            : base(gameStates, characters)
        {
            
        }

        public override void Update()
        {
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
                    if (characters.Count == 0)
                    {
                        Console.WriteLine("You don't have any Characters yet.\n" +
                                          "(press any key to continue)");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                       SelectMode();
                    }
                    break;
                case 2:
                    Console.Clear();
                    gameStates.Push(new CharacterCreator(gameStates, characters));
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
                    gameStates.Push(new SelectCharacter(gameStates, characters));
                    break;
                case 2:
                    //gameStates.Push(new RoomGenerator(gameStates, characters, 40, 15));
                    break;
                default:
                    Console.Write($"Input {input} is a invalid index!\n" +
                                  "Please enter a valid index!\n");
                    break;
            }
        }
    }
}