using System.Diagnostics;
using RPG.characters;

namespace RPG.game_states
{
    public class CharacterCreator : GameState
    {
        public CharacterCreator(Stack<GameState> gameStates, List<Character> characters)
            : base(gameStates, characters)
        {
        }

        // TODO: Implement so that a certain Class gets different values out!
        public override void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    Debug.WriteLine("Created a Bard!");
                    break;
                case 2:
                    Debug.WriteLine("Created a Warlock!");
                    break;
                case 3:
                    Debug.WriteLine("Created a Wizard!");
                    break;
                case 4:
                    Debug.WriteLine("Created a Knight!");
                    break;
                case 5:
                    Debug.WriteLine("Created a Berserk!");
                    break;
                default:
                    Console.WriteLine("Index out of bounds!");
                    break;
            }
        }
    }
}