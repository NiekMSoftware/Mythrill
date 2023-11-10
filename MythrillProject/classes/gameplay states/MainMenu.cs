using MythrillProject.assets;
using MythrillProject.classes.custom_character;

namespace MythrillProject.classes.gameplay_states
{
    public class MainMenu : GameStates
    {
        public MainMenu(Stack<GameStates> gameStates, List<PlayerCharacter> playerCharacters)
                        : base(gameStates, playerCharacters) {
        }

        public override void Update() {
            Console.Write(GUI.GameTitle("Mythrill"));
            Console.Write(GUI.StateName("Main Menu"));
            Console.Write(GUI.StateOptions(1, "Play Game"));
            Console.Write(GUI.StateOptions(2, "Character Creator"));
            Console.Write(GUI.StateOptions(3, "Credits & Copyright"));
            Console.Write(GUI.StateOptions(-1, "Exit"));
            
            ProcessInput(GUI.GetInput("> "));
        }

        public override void ProcessInput(int input) {
            switch (input) {
                case 1:
                    Console.WriteLine("Booting up game...");
                    break;
                case 2:
                    Console.Clear();
                    gameStates.Push(new CharacterCreator(gameStates, playerCharacters));
                    break;
                case 3:
                    Console.WriteLine("Displaying credits...");
                    break;
                case -1:
                    end = true;
                    break;
            }
        }
    }
}