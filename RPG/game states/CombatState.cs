using System.Diagnostics;
using RPG.characters;
using RPG.characters.character_classes;
using RPG.game_managers;
using RPG.interfaces;
using RPG.player_classes;
using RPG.user_interface;

namespace RPG.game_states
{
    public class CombatState : GameState
    {
        private Enemy enemy;
        private Character? player;
        private Random random = new Random();

        public CombatState(Stack<GameState> gameStates, List<Character> characters, List<Character> deadCharacters,
                            Character? character)
            : base(gameStates, characters, deadCharacters)
        {
            player = character;
            if (player != null) enemy = new(player);
            Player.GetPlayer(character);
            Debug.WriteLine($"Enemy name: {enemy.Name}\n" +
                            $"Enemy type:  {enemy.enemyType}\n" +
                            $"Enemy Gender: {enemy.characterGender}\n");
        }

        public override void Update()
        {
            Console.Clear();
            if (!endCombat)
            {
                InstantiateFight();
            }
            else
            {
                Debug.WriteLine($"Popping {this}");
                endState = true;
            }
        }

        private void InstantiateFight()
        {
            // TODO: Start the fight in a loop
            if (player == null)
                return;

            CombatManager.StartCombat(player, enemy);

            endCombat = true;
        }
    }
}