using System.Diagnostics;
using RPG.assets;
using RPG.characters;
using RPG.characters.character_classes;

namespace RPG.game_states
{
    public class CharacterCreator : GameState
    {
        public CharacterCreator(Stack<GameState> gameStates, List<Character> characters)
            : base(gameStates, characters)
        {
        }

        public override void Update()
        {
            Gui.GameState("Character Creator");

            // Show player the options of classes they can pick out of
            Gui.ShowOptions(1, "Bard");
            Gui.ShowOptions(2, "Berserk");
            Gui.ShowOptions(3, "Knight");
            Gui.ShowOptions(4, "Warlock");
            Gui.ShowOptions(5, "Wizard");

            // Ask what the player wants for class for their character
            Console.Write("\nPlease select the Class you would like:\n");
            ProcessInput(Gui.GetInput("> "));
        }

        public override void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    CreateCharacter(new Bard());
                    break;
                case 2:
                    CreateCharacter(new Berserk());
                    break;
                case 3:
                    CreateCharacter(new Knight());
                    break;
                case 4:
                    CreateCharacter(new Warlock());
                    break;
                case 5:
                    CreateCharacter(new Wizard());
                    break;
                default:
                    Console.WriteLine("Index out of bounds!\n" +
                                      "(press any key to continue)");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        /// <summary>
        /// Function creates a new character with a separate class.
        /// This function will also always request a name for the newly created Character.
        /// </summary>
        /// <returns>new Character()</returns>
        private Character? CreateCharacter(Character playerCharacter)
        {
            // Ask the player for a new name
            string? nameInput;

            do
            {
                Console.Write("\n\nPlease enter a valid name (limit of: 2-18 characters): ");
                nameInput = Console.ReadLine();

            } while (nameInput?.Length is <= 2 or >= 18);

            // add the name to the character
            if (nameInput != null) playerCharacter.Name = nameInput;

            Debug.WriteLine($"Returned {playerCharacter.ToString()}, {playerCharacter.ToString()} has the name: {playerCharacter.Name}");

            // Add the new playerCharacter to the list
            characters.Add(playerCharacter);
            Debug.WriteLine($"Count of {characters} is: {characters.Count}");
            return playerCharacter;
        }
    }
}