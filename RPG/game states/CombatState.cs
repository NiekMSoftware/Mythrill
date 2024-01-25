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
        private Enemy enemy = new Enemy();
        private Character? player;
        private Random random = new Random();

        public CombatState(Stack<GameState> gameStates, List<Character> characters, List<Character> deadCharacters,
                            Character? character)
            : base(gameStates, characters, deadCharacters)
        {
            player = character;
            Player.GetPlayer(character);

            enemy.CreateEnemy(enemy);
            enemy.Health = 30;
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