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
            Gui.ShowOptions(1, "Attack");
            Gui.ShowOptions(2, "Defend");
            Gui.ShowOptions(3, "Parry");

            int playerDecisionNumber = InputSystem.GetPlayerDecision("> ");
            int aiDecision = InputSystem.GetAiDecision();

            Console.WriteLine($"Player Name: {player.Name}\n" +
                              $"Player health: {player.Health}/{player.MaxHealth}\n");
            Console.WriteLine($"Enemy Name: {enemy.Name}\n" +
                              $"Enemy health: {enemy.Health}/{enemy.MaxHealth}");

            // Handle input
            HandleInput(playerDecisionNumber, player);
            HandleInput(aiDecision, enemy);

            // Player Decision
            Console.WriteLine($"Player decided to {player.characterDecision}!");

            // AI Decision
            Console.WriteLine($"Enemy decided to {enemy.characterDecision}!");

            // Resolve combat
            if (player.characterDecision == Decision.Attack)
            {
                if (enemy.characterDecision == Decision.Parry && RandomChance(PARRY_SUCCESS_CHANCE))
                {
                    Console.WriteLine("AI Successfully parried the player's attack!");
                }
                else
                {
                    int damageDealt = player.Attack(enemy);
                    Console.WriteLine($"Player dealt {damageDealt} damage to the enemy!\n");
                }
            }
            else if (player.characterDecision == Decision.Defend)
            {
                if (enemy.characterDecision == Decision.Attack && RandomChance(DEFEND_SUCCESS_CHANCE))
                {
                    Console.WriteLine("Player successfully defended against the AI's attack!");
                }
                else
                {
                    int damageTaken = enemy.Attack(player);
                    Console.WriteLine($"Player took {damageTaken} damage from the AI!\n");
                }
            }

            Console.WriteLine($"Player Name: {player.Name}\n" +
                              $"Player health: {player.Health}/{player.MaxHealth}\n");
            Console.WriteLine($"Enemy Name: {enemy.Name}\n" +
                              $"Enemy health: {enemy.Health}/{enemy.MaxHealth}");
        }

        public static void StartCombat(Character player, Character enemy)
        {
            Console.WriteLine("=== Combat Start ===");

            while (player.Health > 0 && enemy.Health > 0)
            {
                ResolveCombat(player, enemy);
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("Player has been defeated. Game Over!");
            }
            else
            {
                Console.WriteLine("Enemy has been defeated. Victory!");
            }

            Console.WriteLine("=== Combat End ===");
        }

        public static void HandleInput(int input, Character character)
        {
            switch (input)
            {
                case 1:
                    character.characterDecision = Decision.Attack;
                    break;
                case 2:
                    character.characterDecision = Decision.Defend;
                    break;
                case 3:
                    character.characterDecision = Decision.Parry;
                    break;
                default:
                    Console.WriteLine("Index out of bounds!\n" +
                                      $"{character} lost their turn!");
                    break;
            }
        }

        private static bool RandomChance(double successChance)
        {
            Random random = new Random();
            return random.NextDouble() < successChance;
        }
    }
}