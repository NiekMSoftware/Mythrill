﻿using System.Diagnostics;
using RPG.characters;
using RPG.combat_strategy;
using RPG.interfaces;
using RPG.user_interface;

namespace RPG.game_managers
{
    public class CombatManager
    {
        private const double PARRY_SUCCESS_CHANCE = 0.7;
        private const double DEFEND_SUCCESS_CHANCE = 0.5;

        /// <summary>
        /// Strategies is a dictionary that saved all decision and handles it accordingly to each key-value.
        /// </summary>
        private static readonly Dictionary<(CharacterData.Decision, CharacterData.Decision), ICombatStrategy> Strategies = new Dictionary<(CharacterData.Decision, CharacterData.Decision), ICombatStrategy>
        {
            {(CharacterData.Decision.Attack, CharacterData.Decision.Parry), new AttackParryStrategy()},
            {(CharacterData.Decision.Attack, CharacterData.Decision.Defend), new AttackDefendStrategy()},
            {(CharacterData.Decision.Defend, CharacterData.Decision.Attack), new DefendAttackStrategy()},
            {(CharacterData.Decision.Attack, CharacterData.Decision.Attack), new AttackAttackStrategy()},
            {(CharacterData.Decision.Parry, CharacterData.Decision.Attack), new ParryAttackStrategy()}
        };

        /// <summary>
        /// ResolveCombat will handle the Combat. Call only when there should be a fight
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public static void ResolveCombat(Character player, Enemy enemy)
        {
            int playerDamage = 0;
            int enemyDamage = 0;

            bool playerSuccess = RandomChance(player.characterDecision == CharacterData.Decision.Parry ? PARRY_SUCCESS_CHANCE : DEFEND_SUCCESS_CHANCE);
            bool enemySuccess = RandomChance(enemy.characterDecision == CharacterData.Decision.Parry ? PARRY_SUCCESS_CHANCE : DEFEND_SUCCESS_CHANCE);
            Console.Clear();

            Console.WriteLine($"{player.Name}:\n" +
                              $"Health: {player.Health}/{player.MaxHealth}\n" +
                              $"Level: {player.Level}\n" +
                              $"EXP: {player.Exp}/{player.MaxExp}\n");

            Console.WriteLine($"{enemy.enemyType}: {enemy.Name}\n" +
                              $"Health: {enemy.Health}/{enemy.MaxHealth}\n" +
                              $"Level: {enemy.Level}");

            Gui.ShowOptions(1, "Attack");
            Gui.ShowOptions(2, "Defend");
            Gui.ShowOptions(3, "Parry");

            int playerDecisionNumber = InputSystem.GetPlayerDecision("> ");
            int aiDecision = InputSystem.GetAiDecision();

            // Handle input
            HandleInput(player, playerDecisionNumber, enemy);
            HandleInput(enemy, aiDecision, player);

            // save the strategy and execute it
            ICombatStrategy strategy = GetStrategy(player.characterDecision, enemy.characterDecision);
            strategy.Execute(player, enemy, playerSuccess, enemySuccess);
        }

        /// <summary>
        /// GetStrategy gathers the strategy from the Strategies dictionary, if successful it returns a valid strategy!
        /// </summary>
        /// <param name="playerDecision"></param>
        /// <param name="enemyDecision"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static ICombatStrategy GetStrategy(CharacterData.Decision playerDecision, CharacterData.Decision enemyDecision)
        {
            // if the playerDecision decides to defend or parry, force the enemyDecision to attack
            if (playerDecision == CharacterData.Decision.Defend || playerDecision == CharacterData.Decision.Parry)
            {
                enemyDecision = CharacterData.Decision.Attack;
            }

            // Try to get the according value, if correct return the strategy
            if (Strategies.TryGetValue((playerDecision, enemyDecision), out var strategy))
            {
                return strategy;
            }

            // else throw an exception
            throw new InvalidOperationException("Invalid combination of decisions");
        }

        public static void StartCombat(Character player, Enemy enemy)
        {
            while (player.Health > 0 && enemy.Health > 0)
            {
                player.Defending = false;
                enemy.Defending = false;

                ResolveCombat(player, enemy);

                // Check if the enemyDecision is defeated
                if (enemy.Health <= 0)
                {
                    Console.WriteLine("Player defeated the enemy. Victory!");
                    
                    // calculate exp
                    switch (enemy.enemyType)
                    {
                        case Enemy.EnemyType.Skeleton:
                            player.Exp += CalculateExp(enemy);
                            break;

                        case Enemy.EnemyType.Goblin:
                            player.Exp += CalculateExp(enemy);
                            break;

                        case Enemy.EnemyType.Warrior:
                            player.Exp += CalculateExp(enemy);
                            break;

                        case Enemy.EnemyType.Valkyrie:
                            player.Exp += CalculateExp(enemy);
                            break;
                    }
                    
                    // level up player
                    if (player.Exp >= player.MaxExp)
                    {
                        Console.WriteLine($"{player.Name} has levelled up!\n" +
                                          $"(press any key to continue)");
                        player.LevelUp();
                        Console.ReadKey();
                    }
                }

                if (player.Health > 0) continue;
                Console.WriteLine("Player was defeated by the enemy. Game Over!\n" +
                                  "(press any key to continue)");
                Console.ReadKey();
            }
        }

        public static void HandleInput(Character decisionMaker, int input, Character target)
        {
            bool validInput = false;

            while (!validInput)
            {
                switch (input)
                {
                    case 1:
                        decisionMaker.characterDecision = CharacterData.Decision.Attack;
                        validInput = true;
                        break;
                    case 2:
                        decisionMaker.characterDecision = CharacterData.Decision.Defend;
                        validInput = true;
                        break;
                    case 3:
                        decisionMaker.characterDecision = CharacterData.Decision.Parry;
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid decision number! Please enter a number between 1 and 3: ");

                        if (!int.TryParse(Console.ReadLine(), out input))
                        {
                            Console.WriteLine("Invalid input! Please enter a number: ");
                        }
                        
                        break;
                }
            }
            
            

            // Set decision after handling input
            decisionMaker.characterDecision = (CharacterData.Decision)input;
        }

        private static bool RandomChance(double successChance)
        {
            Random random = new Random();
            return random.NextDouble() < successChance;
        }

        private static int CalculateExp(Enemy enemy)
        {
            switch (enemy.enemyType)
            {
                case Enemy.EnemyType.Skeleton:
                    return (10 * 2) / 4;

                case Enemy.EnemyType.Goblin:
                    return (10 * 4) / 4;

                case Enemy.EnemyType.Warrior:
                    return (10 * 6) / 2;

                case Enemy.EnemyType.Valkyrie:
                    return (10 * 8) / 2;
                default:
                    return 0;
            }
        }
    }
}