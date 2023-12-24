using System.Diagnostics;
using RPG.characters;
using RPG.characters.character_classes;
using RPG.interfaces;
using RPG.player_classes;
using Type = RPG.characters.Type;

namespace RPG.game_states
{
    public class CombatState : GameState
    {
        private Enemy? enemy = new Enemy();
        private Character? player = new Warlock(Type.Player);
        
        public CombatState(Stack<GameState> gameStates, List<Character> characters) 
                            : base(gameStates, characters)
        {
            Enemy.CreateEnemy(enemy);
        }

        public override void Update()
        {
            InstantiateFight();
        }

        private void InstantiateFight()
        {
            // TODO: Start the fight in a loop
            while (player.IsAlive() && enemy.IsAlive())
            {
                Console.WriteLine($"Player HP: {player.Health}");
                Console.WriteLine($"Enemy HP: {enemy.Health}\n");

                // player turn
                Console.WriteLine("Player's Turn");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Skill");
                Console.Write("Choose an action: ");
                int playerChoice = int.Parse(Console.ReadLine());

                ICharacter playerActions = player;  // Treat the player as ICharacter
                switch (playerChoice)
                {
                    case 1:
                        playerActions.Attack(enemy);
                        break;
                    case 2:
                        playerActions.UseSkill(enemy);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Player lost their turn.");
                        break;
                }

                // Check if enemy is defeated
                if (!enemy.IsAlive())
                {
                    Console.WriteLine("Player defeated the enemy!");
                    break;
                }

                // Enemy's turn
                Console.WriteLine("Enemy's Turn");
                enemy.Attack(player);

                // Check if the player is defeated
                if (player.IsAlive()) continue;

                Console.WriteLine($"Enemy dealt {enemy.CalculateDamage()} damage!");
                Console.WriteLine("Player is defeated!\n");
                break;
            }

            Console.ReadLine();
            endState = true;
        }
    }
}