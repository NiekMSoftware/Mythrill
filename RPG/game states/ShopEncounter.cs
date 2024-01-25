using RPG.characters;
using RPG.user_interface;

namespace RPG.game_states
{
    public class ShopEncounter : GameState
    {
        private Character playerCharacter;

        public ShopEncounter(Stack<GameState> gameStates, List<Character> characters, List<Character> deadCharacters,
        Character playerCharacter)
        : base(gameStates, characters, deadCharacters)
        {
            this.playerCharacter = playerCharacter;
        }
        
        public override void Update()
        {
            Gui.GameState("SHOP");

            Console.WriteLine($"Come get your free beer {playerCharacter.Name}!");
            Gui.ShowOptions(1, "Get a free beer!");
            Gui.ShowOptions(-1, "Exit Shop");
            
            ProcessInput(Gui.GetInput("> "));
        }

        public override void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    Console.WriteLine("'Here ya go!', the bartender said!\n" +
                                      "The beer healed you to full hp!\n");
                    playerCharacter.Health = playerCharacter.MaxHealth;
                    break;
                case -1:
                    endState = true;
                    break;
            }
        }
    }
}