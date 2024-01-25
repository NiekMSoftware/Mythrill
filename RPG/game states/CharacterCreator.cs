using System.Diagnostics;
using RPG.characters;
using RPG.characters.character_classes;
using RPG.user_interface;

namespace RPG.game_states
{
    public class CharacterCreator : GameState
    {
        public CharacterCreator(Stack<GameState> gameStates, List<Character> characters, List<Character> deadCharacters)
            : base(gameStates, characters, deadCharacters)
        {
            this.characters = characters;
        }

        public override void Update()
        {
            // Display Game State
            Gui.GameState("Character Creator");

            // Output the selections the player has
            Gui.ShowOptions(1, "Create Character");
            Gui.ShowOptions(2, "View Characters");
            Gui.ShowOptions(-1, "Return to main menu");

            SelectOption(Gui.GetInput("> "));
        }

        private void SelectOption(int input)
        {
            if (characters.Count != characters.Capacity)
            {
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        ShowClasses();
                        break;
                    case 2:
                        Console.Clear();
                        ShowCharacters();
                        break;
                    case -1:
                        Console.Clear();
                        endState = true;
                        break;
                    default:
                        Console.WriteLine("Index out of bounds!\n" +
                                          "Please enter a valid index!\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("I'm sorry but you have already 10 characters!");
            }
        }
        
        private void ShowClasses()
        {
            Gui.GameState("Select Class");

            // Show player the options of classes they can pick out of
            Gui.ShowOptions(1, "Bard");
            Gui.ShowOptions(2, "Berserk");
            Gui.ShowOptions(3, "Knight");
            Gui.ShowOptions(4, "Warlock");
            Gui.ShowOptions(5, "Wizard");

            // Ask what the player wants for class for their character
            Console.Write("\nPlease select the Class you would like:\n");
            SelectClass(Gui.GetInput("> "));
        }

        private void ShowCharacters()
        {
            if (characters.Count == 0)
            {
                Console.WriteLine("There are no characters to display.\n");
            }
            else
            {
                Gui.GameState("Characters");

                //TODO: Display all characters' names and make the player select them to view or delete them
                foreach (var character in characters)
                {
                    Gui.ShowOptions(0 + 1, character.Name);
                }
            }
        }

        #region Character Creation

        public void SelectClass(int input)
        {
            while (true)
            {
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        CreateCharacter(new Bard());
                        break;
                    case 2:
                        Console.Clear();
                        CreateCharacter(new Berserk());
                        break;
                    case 3:
                        Console.Clear();
                        CreateCharacter(new Knight());
                        break;
                    case 4:
                        Console.Clear();
                        CreateCharacter(new Warlock());
                        break;
                    case 5:
                        Console.Clear();
                        CreateCharacter(new Wizard());
                        break;
                    default:
                        Console.Write("Index out of bounds!\n" + "Please enter a valid index!\n");
                        input = Gui.GetInput("> ");
                        continue;
                }

                break;
            }
        }

        /// <summary>
        /// Function creates a new character with a separate class.
        /// This function will also always request a race, gender and name for the newly created Character.
        /// </summary>
        /// <returns>new Character()</returns>
        private Character CreateCharacter(Character playerCharacter)
        {
            // Display GUI elements
            Gui.GameState("Race Selection");
            Gui.ShowOptions(1, "Dragonborn");
            Gui.ShowOptions(2, "Elf");
            Gui.ShowOptions(3, "Half Elf");
            Gui.ShowOptions(4, "Human");

            Console.WriteLine($"\n=== Character:" +
                              $"\n= Class: {playerCharacter}\n");

            // Select a race
            Console.Write("Please enter a number to select your character's Race: ");
            while (playerCharacter.characterRace == Race.None)
            {
                SelectRace(Gui.GetInput("> "), playerCharacter);
            }

            Console.Clear();

            // Display GUI elements
            Gui.GameState("Gender Selection");
            Gui.ShowOptions(1, "Male");
            Gui.ShowOptions(2, "Female");

            Console.WriteLine($"\n=== Character:" +
                              $"\n= Class: {playerCharacter}" +
                              $"\n= Race: {playerCharacter.characterRace}\n");

            Console.Write("Please enter a number to select your character's Gender: ");

            // Select a gender
            while (playerCharacter.characterGender == Gender.None)
            {
                SelectGender(Gui.GetInput("> "), playerCharacter);
            }

            // Ask the player for a name
            string? nameInput;

            do
            {
                Console.Clear();

                // Gui elements
                Gui.GameState("Name selection");
                Console.WriteLine($"\n=== Character" +
                                  $"\n= Class: {playerCharacter}" +
                                  $"\n= Race: {playerCharacter.characterRace}" +
                                  $"\n= Gender: {playerCharacter.characterGender}");

                Console.Write("\nPlease enter a valid name (limit of: 2-18 characters): ");
                nameInput = Console.ReadLine();

            } while (nameInput?.Length is <= 2 or >= 18);

            // add the name to the character
            if (nameInput != null) playerCharacter.Name = nameInput;

            Debug.WriteLine($"Returned {playerCharacter.ToString()}, {playerCharacter.ToString()} " +
                            $"has the name: {playerCharacter.Name}");

            // Add the character to the list
            characters.Add(playerCharacter);

            // Debugging
            Debug.WriteLine($"Count of {characters} is: {characters.Count}.");
            Debug.WriteLine($"Capacity of {characters} is: {characters.Capacity}.");
            Debug.WriteLine($"Returning {playerCharacter} with these values:\n" +
                            $"Name: {playerCharacter.Name}\n" +
                            $"Gender: {playerCharacter.characterGender}\n" +
                            $"Race: {playerCharacter.characterRace}");

            Console.Clear();
            return playerCharacter;
        }

        private Character SelectRace(int index, Character playerCharacter)
        {
            switch (index)
            {
                case 1:
                    playerCharacter.characterRace = Race.Dragonborn;
                    break;
                case 2:
                    playerCharacter.characterRace = Race.Elf;
                    break;
                case 3:
                    playerCharacter.characterRace = Race.HalfElf;
                    break;
                case 4:
                    playerCharacter.characterRace = Race.Human;
                    break;
                default:
                    Console.Write("Index out of bounds!\n" +
                                  "Please enter a valid number.\n");
                    break;
            }

            return playerCharacter;
        }

        private Character SelectGender(int input, Character playerCharacter)
        {
            switch (input)
            {
                case 1:
                    playerCharacter.characterGender = Gender.Male;
                    break;
                case 2:
                    playerCharacter.characterGender = Gender.Female;
                    break;
                default:
                    Console.WriteLine("Index out of bounds!\n" +
                                      "Please enter a valid number.\n");
                    break;
            }

            return playerCharacter;
        }

        #endregion
    }
}