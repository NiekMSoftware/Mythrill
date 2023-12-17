using System.Diagnostics;
using MythrillRPG.classes.user_interface;

namespace MythrillRPG.classes.game_states
{
    /* What will the MainMenu state do?
     * Display the following items:
     * - Title of the Game
     * - (OPTIONAL) Show which state the player is in
     * - Show what the player can do, simple int input system
     */

    public class MainMenu : GameState
    {
        // Constructor to get and set the new state once called
            // empty for now...
            public MainMenu(Stack<GameState> gameStates) : base(gameStates)
            {
                Debug.WriteLine("Initialized the MainMenu state");
            }

        // Update the User-Interface with the GUI class
        public override void Update()
        {
            GUI.GameTitle("Mythrill's Legacy");
            GUI.PlayerOptions(1, "Play Game");
            GUI.PlayerOptions(2, "Credits");
            GUI.PlayerOptions(-1, "Exit");

            // Process the input with the GetInput function in GUI
            ProcessInput(GUI.GetInput("> "));
        }

        // Override the ProcessInput method of the base class
        public override void ProcessInput(int input)
        {
            // Switch the input
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Running Game!");
                    gameStates.Push(new CombatState(gameStates));
                    break;
                case 2:
                    Console.WriteLine("Displaying Credits!");
                    break;
                case -1:
                    endState = true;
                    break;
            }
        }
    }
}