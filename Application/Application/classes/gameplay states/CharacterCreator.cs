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
            Debug.WriteLine("Created Character Creator stack!");
        }
        
        // TODO: Update the game's GUI
            // - Process user Input
            // - Allow the user to create a character
            // - Roll a dice for attributes
    }
}