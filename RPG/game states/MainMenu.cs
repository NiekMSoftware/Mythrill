using System.Diagnostics;

namespace RPG.game_states
{
    public class MainMenu : GameState
    {
        public MainMenu(Stack<GameState> gameStates) : base(gameStates)
        {
            Debug.WriteLine("Created the MainMenu State");
        }

        public override void Update()
        {
            Console.WriteLine("Running MainMenu state");
        }
    }
}