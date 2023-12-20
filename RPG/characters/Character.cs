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

        public int RemoveSkillPoint(int skillPoint)
        {
            throw new NotImplementedException();
        }

        public int GainSkillPoint(int skillPoint)
        {
            throw new NotImplementedException();
        }
    }
}