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
                    Console.Clear();
                    InitializeCharacter();
                    break;
                case 2:
                    Console.WriteLine("Viewing Characters");
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
        
        
        // TODO: Create the following methods to create a Character:
            // - pubic void CreateCharacter(), initialize the player's name and other attributes
            // - private void RollAttributes, basically rolls a dice from 1-16 for the attributes

        
        private void InitializeCharacter() {
            int minLength = 3;
            int maxLength = 20;
            
            // Show the player what they are in
            Console.Write(GUI.StateName("Create Character"));
            
            // Ask the Player for a name
            Console.Write("Please insert a name(between 3 and 20 characters): ");
            string name = Console.ReadLine();
            
            // Check if the string is empty and if the characters in the string are between 3-20 chars.
            if (string.IsNullOrEmpty(name) || name.Length < minLength || name.Length > maxLength) {
                Console.WriteLine($"The name should be between the {minLength} and {maxLength} characters long.");
                InitializeCharacter();
            } else {
                // Ask the player if he wants to Randomize all the attributes completely
                Console.WriteLine("Would you like to randomize this character's attributes? (y/n)");
                string input = Console.ReadLine();
                
                // Switch the input
                switch (input) {
                    case "y":
                        // Randomize all attributes
                        break;
                    case "n":
                        // Let the player decide for himself
                        Console.Clear();
                        RollAttributes();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input...");
                        break;
                }
            }
        }

        private void RollAttributes() {
            
        }
    }
}