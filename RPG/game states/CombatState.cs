using System.Diagnostics;
using RPG.characters;
using RPG.characters.character_classes;
using RPG.interfaces;
using RPG.player_classes;

namespace RPG.game_states
{
    public class CombatState : GameState
    {
        private Enemy enemy = new();
        private Character? player;
        private Random random = new Random();

        public CombatState(Stack<GameState> gameStates, List<Character> characters,
                            Character character)
            : base(gameStates, characters)
        {
            player = character;
            Player.GetPlayer(character);

            enemy.CreateEnemy(enemy);
        }

        public override void Update()
        {
            Gui.GameState("Combat State");
            if (!endCombat)
            {
                InstantiateFight(enemy);
            }
            else
            {
                Debug.WriteLine($"Popping {this}");
                endState = true;
            }
        }

        private void PlayerDecision()
        {
            if (player == null)
                return;

            // TODO: Create a GUI for the player
            Gui.ShowOptions(1, "Attack");
            Gui.ShowOptions(2, "Defend");

            // Gather Input and switch it.
            int input = Gui.GetInput("> ");
            switch (input)
            {
                case 1:
                    player.characterDecision = Decision.Attack;
                    break;
                case 2:
                    player.characterDecision = Decision.Defend;
                    break;
                default:
                    Console.WriteLine($"Index: {input} was out of bounds!\n" +
                                      $"You lost your turn!");
                    break;
            }
        }

        private void EnemyDecision()
        {
            // Simulate enemy-decision making
            int decision = random.Next(1, 3);   // 1 for Attack, 2 for Defend
            enemy.characterDecision = (decision == 1) ? Decision.Attack : Decision.Defend;
        }

        private void ApplyDecisions()
        {
            if (player == null)
                return;

            // Apply player decision
            switch (player.characterDecision)
            {
                case Decision.Attack:
                    player.Attack(enemy);
                    break;
                case Decision.Defend:
                    player.Defend(enemy);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Apply enemy decision
            switch (enemy.characterDecision)
            {
                case Decision.Attack:
                    enemy.Attack(player);
                    break;
                case Decision.Defend:
                    enemy.Defend(player);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    break;
            }
        }

        private void InstantiateFight(Enemy enemy)
        {
            // TODO: Start the fight in a loop
            if (player == null)
                return;

            while (player.Health > 0 && enemy.Health > 0)
            {
                PlayerDecision();
                EnemyDecision();
                ApplyDecisions();

                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"{enemy.Name} has been defeated!\n" +
                                      $"You won the fight!");
                    break;
                }

                if (player.Health > 0) continue;

                Console.WriteLine($"{player.Name} has been defeated!\n" +
                                  $"You won the fight!");
                break;
            }

            endCombat = true;
        }
    }
}