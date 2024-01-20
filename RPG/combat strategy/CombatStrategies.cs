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
                Debug.WriteLine($"{enemy.Name} has blocked the attack!");
                int playerDamage = enemy.Defend();
                enemy.Health -= playerDamage;
                Debug.WriteLine($"{enemy.Name} health: {enemy.Health}");
            }
            else
            {
                Debug.WriteLine($"{enemy.Name} has failed to block the attack!");
                int playerDamage = player.Attack();
                enemy.Health -= playerDamage;
                Debug.WriteLine($"{enemy.Name} health: {enemy.Health}");
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
                Debug.WriteLine($"{enemy.Name} has blocked the attack!");
                int playerDamage = enemy.Defend();
                enemy.Health -= playerDamage;
                Debug.WriteLine($"{enemy.Name} health: {enemy.Health}");
            }
            else
            {
                Debug.WriteLine($"{enemy.Name} has failed to block the attack!");
                int playerDamage = player.Attack();
                enemy.Health -= playerDamage;
                Debug.WriteLine($"{enemy.Name} health: {enemy.Health}");
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

            Console.WriteLine($"Both {player.Name} and {enemy.Name} attack each other!\n" +
                              $"{player.Name} dealt: {playerDamage} damage to the enemy!\n" +
                              $"{enemy.Name} dealt: {enemyDamage} to their opponent!\n");
        }
    }

    // handles where player defends and enemy attacks
    public class DefendAttackStrategy : ICombatStrategy
    {
        public void Execute(Character player, Character enemy, bool playerSuccess, bool enemySuccess)
        {
            if (playerSuccess)
            {
                Debug.WriteLine($"{player.Name} successfully defended the attack!");
                int enemyDamage = player.Defend();
                player.Health -= enemyDamage;
                Debug.WriteLine($"{player.Name} health: {player.Health}");
            }
            else
            {
                Debug.WriteLine($"{player.Name} failed to defend!");
                int enemyDamage = enemy.Attack();
                player.Health -= enemyDamage;
                Debug.WriteLine($"{player.Name} health: {player.Health}");
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
                Debug.WriteLine($"{player} successfully parried the attack!");
                int playerDamage = player.Parry();
                enemy.Health -= playerDamage;
            }
            else
            {
                Debug.WriteLine("Player failed parrying the attack!");
                int enemyDamage = enemy.Attack();
                player.Health -= enemyDamage;
            }
        }
    }
}