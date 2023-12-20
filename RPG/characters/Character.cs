using RPG.interfaces;

namespace RPG.characters
{
    public abstract class Character : CharacterData, ICharacter
    {
        public virtual void Attack()
        {
            throw new NotImplementedException();
        }

        public virtual void Defend()
        {
            throw new NotImplementedException();
        }

        public virtual void Heal()
        {
            throw new NotImplementedException();
        }
    }

    public class Warrior : Character
    {
        
    }
}