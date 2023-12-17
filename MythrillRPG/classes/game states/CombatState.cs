using System.Diagnostics;
using MythrillRPG.abstract_classes;
using MythrillRPG.classes.character_classes;
using MythrillRPG.classes.user_interface;

namespace MythrillRPG.classes.game_states
{
    public class CombatState : GameState
    {
        public CombatState(Stack<GameState> gameStates) : base(gameStates)
        {
            Debug.WriteLine("Initiated Combat!");
        }

        public override void Update()
        {
            GUI.GameTitle("COMBAT");
        }
    }
}