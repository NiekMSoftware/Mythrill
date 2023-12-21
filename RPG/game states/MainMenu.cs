using System.Diagnostics;
using RPG.assets;
using RPG.characters;

namespace RPG.game_states
{
    public class MainMenu : GameState
    {
        public MainMenu(Stack<GameState> gameStates, List<Character> characters) 
            : base(gameStates, characters)
        {
            Debug.WriteLine("Created the MainMenu State");
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
                    Console.WriteLine("Starting Game");
                    break;
                case 2:
                    Console.WriteLine("Displaying Character Creator");
                    gameStates.Push(new CharacterCreator(gameStates, characters));
                    break;
                case 3:
                    Console.WriteLine("Displaying Options");
                    break;
                case -1:
                    end = true;
                    break;
                default:
                    Console.WriteLine($"Index: {input} is out of bounds.\n" +
                                      $"(press any key to continue)\n\n");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}