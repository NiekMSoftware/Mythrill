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
            enemy.Health = 30;
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
            Console.WriteLine($"Player Health: {player.Health}/{player.MaxHealth}\n" +
                              $"Enemy Health: {enemy.Health}/{enemy.MaxHealth}");

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

        private void ApplyPlayerDecision()
        {
            switch (player?.characterDecision)
            {
                case Decision.Attack:
                    player.Attack(enemy);
                    break;
                case Decision.Defend:
                    player.Defend(enemy);
                    break;
            }
        }

        private void InstantiateFight(Enemy enemy)
        {
            // TODO: Start the fight in a loop
            if (player == null)
                return;

            CombatManager.StartCombat(player, enemy);

            endCombat = true;
        }
    }
}