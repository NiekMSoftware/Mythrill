using System.Diagnostics;
using MythrillRPG.classes.room_generation;
using MythrillRPG.classes.user_interface;

namespace MythrillRPG.classes.game_states
{
    public class GenerateRoomState : GameState
    {
        private RoomGenerator roomGenerator;

        public GenerateRoomState(Stack<GameState> gameStates) : base(gameStates)
        {
            InitRoom();
            Debug.WriteLine("Generate Room state initiated");
        }

        private void InitRoom()
        {
            roomGenerator = new RoomGenerator();

            // Initialize the room
            roomGenerator.InitializeRoom();
        }

        public override void Update()
        {
            ProcessInput(GUI.GetInput("> "));
        }

        public override void ProcessInput(int input)
        {
            switch (input)
            {
                case -1:
                    Console.Clear();
                    endState = true;
                    break;
            }
        }
    }
}