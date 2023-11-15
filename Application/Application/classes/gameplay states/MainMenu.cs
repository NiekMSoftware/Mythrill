using System.Diagnostics;
using Application.assets;
using Application.classes.abstract_classes;
using Application.interfaces;

namespace Application.classes.gameplay_states
{
    public class MainMenu : GameState
    {
        public MainMenu(Stack<GameState> gameStates, List<ICharacter> pChars) : base(gameStates, pChars) {
            Debug.WriteLine("Created the Main Menu stack!");
        }
        
        public override void Update() {
            // Display GUI
            Console.Write(GUI.Title("TEMP NAME"));
            Console.Write(GUI.Selection(1, "Play"));
            Console.Write(GUI.Selection(2, "Character Creator"));
            Console.Write(GUI.Selection(-1, "Quit"));
            
            // Process input
            ProcessInput(GUI.GetInput("> "));
        }

        private void ProcessInput(int input) {
            switch (input) {
                case 1:
                    Console.WriteLine("Running Application!");
                    break;
                case 2:
                    // Push character creator stack
                    Console.WriteLine("Character Creator");
                    gameStates.Push(new CharacterCreator(gameStates, playerChars));
                    break;
                case -1:
                    end = true;
                    break;
            }
        }
    }
}