using System.Diagnostics;
using RPG.characters;
using RPG.user_interface;

namespace RPG.game_managers
{
    public class CombatManager
    {
        private const double PARRY_SUCCESS_CHANCE = 0.7;
        private const double DEFEND_SUCCESS_CHANCE = 0.5;

        /// <summary>
        /// ResolveCombat will handle the Combat. Call only when there should be a fight
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public static void ResolveCombat(Character player, Character enemy)
        {
            int playerDamage = 0;
            int enemyDamage = 0;

            bool aiParrySuccess = RandomChance(PARRY_SUCCESS_CHANCE);
            bool aiDefendSuccess = RandomChance(DEFEND_SUCCESS_CHANCE);
            bool playerParrySuccess = RandomChance(PARRY_SUCCESS_CHANCE);
            bool playerDefendSuccess = RandomChance(DEFEND_SUCCESS_CHANCE);

            Console.WriteLine($"Player Name: {player.Name}\n" +
                              $"Player health: {player.Health}/{player.MaxHealth}\n");
            Console.WriteLine($"Enemy Name: {enemy.Name}\n" +
                              $"Enemy health: {enemy.Health}/{enemy.MaxHealth}");

            Gui.ShowOptions(1, "Attack");
            Gui.ShowOptions(2, "Defend");
            Gui.ShowOptions(3, "Parry");

            int playerDecisionNumber = InputSystem.GetPlayerDecision("> ");
            int aiDecision = InputSystem.GetAiDecision();

            // Handle input
            HandleInput(player, playerDecisionNumber, enemy);
            HandleInput(enemy, aiDecision, player);

            // TODO: Get rid of the default occurence by checking all decisions
            // Switch decisions
            switch (player.characterDecision)
            {
                // Resolve combat
                case Decision.Attack when enemy.characterDecision == Decision.Parry && aiParrySuccess:
                    Debug.WriteLine("Enemy parried!");

                    // gather damage and output it
                    enemyDamage = enemy.Parry();
                    player.Health -= enemyDamage;
                    Debug.WriteLine($"{player} health: {player.Health}");
                    break;
                case Decision.Attack when enemy.characterDecision == Decision.Parry && !aiParrySuccess:
                    Debug.WriteLine($"{enemy} failed to parry!");

                    // gather damage and output it
                    playerDamage = player.Attack();
                    enemy.Health -= playerDamage;
                    Debug.WriteLine($"{enemy} health: {enemy.Health}");
                    break;
                case Decision.Attack when enemy.characterDecision == Decision.Defend && aiDefendSuccess:
                    Debug.WriteLine($"{enemy} has blocked the attack!");
                    // save the damage
                    playerDamage = enemy.Defend();

                    // reduce the health
                    enemy.Health -= playerDamage;
                    Debug.WriteLine($"{enemy} health: {enemy.Health}");
                    break;
                case Decision.Attack when enemy.characterDecision == Decision.Defend && !aiDefendSuccess:
                    Debug.WriteLine($"{enemy} has failed to block the attack!");
                    playerDamage = player.Attack();
                    enemy.Health -= playerDamage;
                    Debug.WriteLine($"{enemy} health: {enemy.Health}");
                    break;
                case Decision.Attack when enemy.characterDecision == Decision.Attack:
                    Debug.WriteLine("Both the Player and Ai attacked!");
                    // save both damage outputs
                    playerDamage = player.Attack();
                    enemyDamage = enemy.Attack();

                    // reduce health
                    player.Health -= enemyDamage;
                    enemy.Health -= playerDamage;
                    Debug.WriteLine($"Health {player}: {player.Health}\n" +
                                    $"Health {enemy}: {enemy.Health}");
                    break;
                case Decision.Defend when enemy.characterDecision == Decision.Attack && playerDefendSuccess:
                    Debug.WriteLine($"{player} successfully defended the attack!");
                    enemyDamage = player.Defend();
                    player.Health -= enemyDamage;

                    Debug.WriteLine($"{player} health: {player.Health}");
                    break;
                case Decision.Defend when enemy.characterDecision == Decision.Attack && !playerDefendSuccess:
                    Debug.WriteLine($"{player} failed to defend!");
                    enemyDamage = enemy.Attack();
                    player.Health -= enemyDamage;

                    Debug.WriteLine($"{player} health: {player.Health}");
                    break;
                case Decision.Defend when enemy.characterDecision == Decision.Defend:
                    Console.WriteLine("Both of you were defending.. Nothing exciting happened.");
                    break;
                case Decision.Parry when enemy.characterDecision == Decision.Attack && playerParrySuccess:
                    Debug.WriteLine($"{player} successfully parried the attack!");
                    playerDamage = player.Parry();
                    enemy.Health -= playerDamage;
                    break;
                case Decision.Parry when enemy.characterDecision == Decision.Attack && !playerParrySuccess:
                    Debug.WriteLine($"{player} failed to parry the attack!");
                    enemyDamage = enemy.Attack();
                    player.Health -= enemyDamage;
                    break;
                case Decision.Parry when enemy.characterDecision == Decision.Defend:
                    Console.WriteLine("You really tried to parry a shield that is blocking?\n" +
                                      "Now that is crazy...");
                    break;
                case Decision.Parry when enemy.characterDecision == Decision.Parry:
                    Console.WriteLine("The enemy parried your parry... wait what?" +
                                      "Interesting, but nothing happened!");
                    break;
                default:
                    Console.WriteLine($"Yes.");
                    break;
            }
        }

        public static void StartCombat(Character player, Character enemy)
        {
            Console.WriteLine("=== Combat Start ===");

            while (player.Health > 0 && enemy.Health > 0)
            {
                player.Defending = false;
                enemy.Defending = false;

                ResolveCombat(player, enemy);

                // Check if the enemy is defeated
                if (enemy.Health <= 0)
                {
                    Console.WriteLine("Player defeated the enemy. Victory!");
                    break;
                } 
                if (player.Health <= 0)
                {
                    Console.WriteLine("Player was defeated by the enemy. Game Over!");
                    break;
                }
            }

            Console.WriteLine("=== Combat End ===");
        }

        public static void HandleInput(Character decisionMaker, int input, Character target)
        {
            switch (input)
            {
                case 1:
                    if (!target.Defending)
                    {
                        decisionMaker.characterDecision = Decision.Attack;
                    }
                    break;
                case 2:
                    decisionMaker.Defending = true;
                    break;
                case 3:
                    if (!target.Defending)
                    {
                        decisionMaker.characterDecision = Decision.Parry;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid decision number!");
                    break;
            }

            // Set decision after handling input
            decisionMaker.characterDecision = (Decision)input;
        }

        private static bool RandomChance(double successChance)
        {
            Random random = new Random();
            return random.NextDouble() < successChance;
        }
    }
}