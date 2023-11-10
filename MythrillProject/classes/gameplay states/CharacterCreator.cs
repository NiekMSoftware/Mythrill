using MythrillProject.assets;
using MythrillProject.classes.custom_character;

namespace MythrillProject.classes.gameplay_states
{
    public class CharacterCreator : GameStates
    {
        public CharacterCreator(Stack<GameStates> gameStates, List<PlayerCharacter> playerCharacters) 
                                : base(gameStates, playerCharacters) {
        }

        public override void Update() {
            Console.Write(GUI.StateName("Character Creator"));
            Console.Write(GUI.StateOptions(1, "Create"));
            Console.Write(GUI.StateOptions(2, "View Characters"));
            Console.Write(GUI.StateOptions(3, "Delete Character"));
            Console.Write(GUI.StateOptions(-1, "Exit"));
            
            ProcessInput(GUI.GetInput("> "));
        }

        public override void ProcessInput(int input) {
            switch (input) {
                case 1:
                    Console.WriteLine("Create Character");
                    break;
                case 2:
                    Console.WriteLine("View Character");
                    break;
                case 3:
                    Console.WriteLine("Delete Character");
                    break;
                case -1:
                    Console.Clear();
                    end = true;
                    break;
            }
        }
    }
}