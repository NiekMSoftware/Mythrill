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
            InstantiateFight(enemy);
        }

        private void InstantiateFight(Enemy enemy)
        {
            // TODO: Start the fight in a loop
            Console.WriteLine($"{player.Name} vs. {enemy.Name}");

            while (player.Health > 0 && enemy.Health > 0)
            {
                // Player's turn
                Console.WriteLine($"{player.Name} turn.");

                Gui.ShowOptions(1, "Attack");
                Gui.ShowOptions(2, "Defend");

                int input = Gui.GetInput("> ");
                switch (input)
                {
                    case 1:
                        player.Attack(enemy);
                        break;
                    case 2:
                        player.Defend(enemy);
                        break;
                    default:
                        Console.WriteLine($"Index: {input} was out of bounds!\n" +
                                          $"You lost your turn!");
                        break;
                }

                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"{enemy.Name} has been defeated!\n" +
                                      $"You won the fight!");
                    break;
                }

                // Enemy's turn
                enemy.Attack(player);   // for now attack the player
                if (player.Health <= 0)
                {
                    Console.WriteLine($"{player.Name} has been defeated!\n" +
                                      $"You lost the fight!");
                    break;
                }
            }

            endState = true;
        }
    }
}