using System.Diagnostics;
using RPG.characters;
using RPG.game_states.endless;
using RPG.player_classes;

namespace RPG.game_states
{
    public class EndlessState : GameState
    {
        private Character playerCharacter;

        private Room room;

        private bool shouldPrintRoom = false;
        private bool wentToShop = false;

        public EndlessState(Stack<GameState> gameStates, List<Character> characters, List<Character> deadCharacters,
            Character? playerChar, Room room) 
            : base(gameStates, characters, deadCharacters)
        {
            this.room = room;

            if (playerChar != null)
            {
                playerCharacter = playerChar;
            }
        }

        public override void Update()
        {
            // make sure the terminal is not buffering after the player moves
            Console.CursorVisible = false;

            // if the enemies are dead, push in a new state
            if (room.CollisionEnemy)
            {
                Debug.WriteLine($"Room collisionbool: {room.CollisionEnemy}");
                gameStates.Push(new CombatState(gameStates, characters, deadCharacters, 
                playerCharacter, false));
                
                // check if player has died
                if (playerCharacter.Health <= 0)
                    endState = true;
                else
                {
                    room.CollisionEnemy = false;
                    shouldPrintRoom = true;
                }
            }
            else
            {
                if (playerCharacter.Health <= 0)
                    endState = true;

                // check if there are still enemies left in the room, if not. Push in shop state
                if (room.Enemies.Count == 0 && !wentToShop)
                {
                    if (playerCharacter.Health <= 0)
                        endState = true;
                    else
                    {
                        Debug.WriteLine("No enemies left... pushing in Shop state...");
                        wentToShop = true;
                        gameStates.Push(new ShopEncounter(gameStates, characters, deadCharacters, playerCharacter));
                    }
                }
                else
                {
                    if (shouldPrintRoom)
                    {
                        Console.Clear();
                        room.PrintOriginalRoom();
                        shouldPrintRoom = false;
                    }
                    else if (wentToShop)
                    {
                        Console.Clear();
                        // TODO: Generate a new Room with new enemies!
                    }
                    room.UpdateRoom();
                }
            }
        }
    }
}