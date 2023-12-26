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
            Console.WriteLine($"Player: {player.Name} | {player} is against {enemy.Name} | {enemy}");

            Gui.ShowOptions(1, "Attack");
            Gui.ShowOptions(2, "Defend");
            Gui.ShowOptions(3, "Use Skill");

            // process player input
            if (player.IsAlive())
            {
                ProcessInput(Gui.GetInput("> "));
            }
            else
            {
                return;
            }

            // process enemy action
            if (enemy.IsAlive())
            {
                enemy.Attack(player);
            }
        }

        public override void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    player.Attack(enemy);
                    break;
                case 2:
                    player.Defend(enemy);
                    break;
                case 3:
                    player.UseSkill(enemy);
                    break;
                default:
                    Console.WriteLine("You gave in a wrong input.\n" +
                                      "You lost your move!");
                    break;
            }
        }
    }
}