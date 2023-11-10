using MythrillProject.assets;

namespace MythrillProject.classes.gameplay_states
{
    public class MainMenu : GameStates
    {
        public MainMenu(Stack<GameStates> gameStates) : base(gameStates) {
            
        }

        public override void Update() {
            Console.Write(GUI.GameTitle("Mythrill"));
            Console.Write(GUI.StateName("Main Menu"));
            Console.Write(GUI.StateOptions(1, "Play Game"));
            Console.Write(GUI.StateOptions(2, "Credits & Copyright"));
            Console.Write(GUI.StateOptions(-1, "Exit"));
            
            ProcessInput(GUI.GetInput("> "));
        }

        private void ProcessInput(int input) {
            switch (input) {
                case 1:
                    Console.WriteLine("Booting up game...");
                    break;
                case 2:
                    Console.WriteLine("Displaying credits...");
                    break;
                case -1:
                    Console.WriteLine("Ending Game...");
                    end = true;
                    break;
            }
        }
    }
}