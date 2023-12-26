using System.Diagnostics;
using RPG.characters;

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
                        gameStates.Push(new SelectCharacter(gameStates, characters));
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
    }
}