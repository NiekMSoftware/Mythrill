using System.Diagnostics;
using Application.classes.abstract_classes;

namespace Application.classes
{
    public class MainMenu : GameState
    {
        public MainMenu(Stack<GameState> gameStates) : base(gameStates) {
            Debug.WriteLine("Created the Main Menu stack!");
        }

        public override void Update() {
            
        }
    }
}