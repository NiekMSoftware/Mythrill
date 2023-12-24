﻿using System.Diagnostics;
using RPG.characters;
using RPG.player_classes;

namespace RPG.game_states
{
    public class CombatState : GameState
    {
        private readonly Enemy enemy = new();
        private readonly Player player = new();
        
        public CombatState(Stack<GameState> gameStates, List<Character> characters) 
                            : base(gameStates, characters)
        {
            Enemy.CreateEnemy(enemy);

            InstantiateFight(player, enemy);
        }

        public override void Update()
        {
            
        }

        private void InstantiateFight(Player player, Enemy enemy)
        {
            // TODO: Start the fight in a loop
            
        }
    }
}