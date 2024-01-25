using System.Diagnostics;
using RPG.characters;
using RPG.interfaces;

namespace RPG.combat_strategy
{
    // PLAYER HANDLING

    // handles when player attacks and enemy parries
    public class AttackParryStrategy : ICombatStrategy
    {
        public void Execute(Character player, Character enemy, bool playerSuccess, bool enemySuccess)
        {
            if (enemySuccess)
            {
                int enemyDamage = enemy.Parry();
                
                Console.WriteLine($"{enemy.Name} has parried the attack!\n" +
                                  $"{player.Name} has received: {enemyDamage} damage!");
                Console.ReadKey();
                player.Health -= enemyDamage;
            }
            else
            {
                int playerDamage = player.Attack();
                
                Console.WriteLine($"{enemy.Name} has failed to parry the attack!\n" +
                                  $"{player.Name} dealt: {playerDamage} damage to {enemy.Name}!");
                Console.ReadKey();
                enemy.Health -= playerDamage;
            }
        }
    }

    // handles player attacks & enemy defends
    public class AttackDefendStrategy : ICombatStrategy
    {
        public void Execute(Character player, Character enemy, bool playerSuccess, bool enemySuccess)
        {
            if (enemySuccess)
            {
                int playerDamage = enemy.Defend();
                
                Console.WriteLine($"{enemy.Name} has blocked the attack!\n" +
                                  $"{player.Name} dealt: {playerDamage} damage to {enemy.Name}!");
                Console.ReadKey();
                
                enemy.Health -= playerDamage;
            }
            else
            {
                int playerDamage = player.Attack();
                
                Console.WriteLine($"{enemy.Name} has failed to block the attack!\n" +
                                  $"{player.Name} dealt: {playerDamage} damage to {enemy.Name}!");
                Console.ReadKey();
                
                enemy.Health -= playerDamage;
            }
        }
    }

    // handles both attacks
    public class AttackAttackStrategy : ICombatStrategy
    {
        public void Execute(Character player, Character enemy, bool playerSuccess, bool enemySuccess)
        {
            // get damage
            int playerDamage = player.Attack();
            int enemyDamage = enemy.Attack();

            // handle health
            enemy.Health -= playerDamage;
            player.Health -= enemyDamage;

            Console.WriteLine($"Both {player.Name} and {enemy.Name} attacked each other!\n" +
                              $"{player.Name} dealt: {playerDamage} damage to the enemy!\n" +
                              $"{enemy.Name} dealt: {enemyDamage} to {player.Name}!\n");
            Console.ReadKey();
        }
    }

    // handles where player defends and enemy attacks
    public class DefendAttackStrategy : ICombatStrategy
    {
        public void Execute(Character player, Character enemy, bool playerSuccess, bool enemySuccess)
        {
            if (playerSuccess)
            {
                int enemyDamage = player.Defend();
                
                Console.WriteLine($"{player.Name} successfully defended the attack!\n" +
                                  $"{enemy.Name} dealt: {enemyDamage} damage to {player.Name}!");
                Console.ReadKey();
                
                player.Health -= enemyDamage;
            }
            else
            {
                int enemyDamage = enemy.Attack();
                
                Console.WriteLine($"{player.Name} failed to defend!\n" +
                                  $"{enemy.Name} dealt {enemyDamage} damage {player.Name}");
                Console.ReadKey();
                
                player.Health -= enemyDamage;
            }
        }
    }

    // handles when player is parrying & enemy is attacking
    public class ParryAttackStrategy : ICombatStrategy
    {
        public void Execute(Character player, Character enemy, bool playerSuccess, bool enemySuccess)
        {
            if (playerSuccess)
            {
                int playerDamage = player.Parry();
                
                Console.WriteLine($"{player.Name} successfully parried the attack!\n" +
                                  $"{player.Name} dealt {playerDamage} damage to {enemy.Name}");
                Console.ReadKey();
                
                enemy.Health -= playerDamage;
            }
            else
            {
                int enemyDamage = enemy.Attack();
             
                Console.WriteLine($"{player.Name} failed parrying the attack!\n" +
                                  $"{enemy.Name} dealt: {enemyDamage} damage to {player.Name}!);");
                Console.ReadKey();
                
                player.Health -= enemyDamage;
            }
        }
    }
}