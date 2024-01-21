using RPG.characters;

namespace RPG.game_states.endless
{
    public class Wave
    {
        public List<Character> Enemies { get; set; }

        public Wave(List<Character> enemies)
        {
            Enemies = enemies;
        }

        public bool IsCompleted()
        {
            return Enemies.All(e => e.IsAlive());
        }
    }
}
