using RPG.characters;

namespace RPG
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
            HandleInput(player, playerDecisionNumber, player);
            HandleInput(enemy, aiDecision, player);

            // Player Decision
            Console.WriteLine($"Player decided to {player.characterDecision}!");

            // AI Decision
            Console.WriteLine($"Enemy decided to {enemy.characterDecision}!");

            switch (player.characterDecision)
            {
                // Resolve combat
                case Decision.Attack when enemy.characterDecision == Decision.Parry && RandomChance(PARRY_SUCCESS_CHANCE):
                    Console.WriteLine("AI Successfully parried the player's attack!");
                    break;
                case Decision.Attack:
                case Decision.Defend when enemy.characterDecision == Decision.Attack && RandomChance(DEFEND_SUCCESS_CHANCE):
                    Console.WriteLine("Player successfully defended against the AI's attack!");
                    break;
                default:
                    int damageTaken = enemy.Attack(player);
                    Console.WriteLine($"Player took {damageTaken} damage from the AI!");
                    break;
            }
        }

        public static void StartCombat(Character player, Character enemy)
        {
            Console.WriteLine("=== Combat Start ===");

            while (player.Health > 0 && enemy.Health > 0)
            {
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
                    decisionMaker.Attack(target);
                    break;
                case 2:
                    decisionMaker.characterDecision = Decision.Defend;
                    break;
                case 3:
                    decisionMaker.Parry(target);
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