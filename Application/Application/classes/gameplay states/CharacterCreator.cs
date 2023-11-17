using System.Diagnostics;
using Application.assets;
using Application.classes.abstract_classes;
using Application.interfaces;

namespace Application.classes.gameplay_states
{
    public class CharacterCreator : GameState
    {
        public CharacterCreator(Stack<GameState> gameStates, List<ICharacter> playerChars)
                                : base(gameStates, playerChars) {
            Debug.WriteLine("Added Character Creator stack!\n");
        }
        
        // TODO: Update the game's GUI
            // - Process user Input
            // - Allow the user to create a character
            // - Roll a dice for attributes

        public override void Update() {
            Console.Write(GUI.Title("Character Creator"));
            Console.Write(GUI.Selection(1, "Create"));
            Console.Write(GUI.Selection(2, "Show"));
            Console.Write(GUI.Selection(3, "Delete"));
            Console.Write(GUI.Selection(-1, "Return to Main Menu"));
            
            // Process player Input
            ProcessInput(GUI.GetInput("> "));
        }

        protected override void ProcessInput(int input) {
            switch (input) {
                case 1:
                    // Function to Create a character
                    CreateCharacter();
                    break;
                case 2:
                    // Function to show all characters
                    break;
                case 3:
                    // Function to delete specific character
                    break;
                case -1:
                    Console.Clear();
                    end = true;
                    Debug.WriteLine($"Popped {this}");
                    break;
            }
        }

        private void CreateCharacter() {
            // Function to ask for a name for the character
            AskName();
        }

        private void AskName() {
            // Save the values of min and max value 
            int minValue = 3;
            int maxValue = 20;
            
            while (true) {
                // Ask the user for a name for their Character
                Console.Write($"Please enter a name ({minValue} - {maxValue}): ");
                
                // Save the user their input
                string? userInput = Console.ReadLine();
                if (userInput != null && userInput.ToLower().Length >= minValue && userInput.ToLower().Length <= maxValue)
                {
                    ICharacter playerChar = new ICharacter
                    {
                        Name = userInput
                    };
                    
                    playerChars.Add(playerChar);
                    int index = playerChars.IndexOf(playerChar);
                    
                    Debug.WriteLine($"Added new character with the name: {playerChars[index].Name}");
                    break;
                } else {
                    Console.WriteLine("Please enter a valid length of your Character's name!\n" +
                                      "(press any key to continue...)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}