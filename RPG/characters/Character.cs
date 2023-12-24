using RPG.interfaces;

namespace RPG.characters
{
    public abstract class Character : CharacterData, ICharacter
    {
        public void TakeTurn(Character opponent)
        {
            throw new NotImplementedException();
        }

        public void AttackEnemy(Character opponent)
        {
            throw new NotImplementedException();
        }

        public void Defend()
        {
            throw new NotImplementedException();
        }

        public void Heal()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public int TakeSkillPoint(int skillPoint)
        {
            throw new NotImplementedException();
        }

        public int GainSkillPoint(int skillPoint)
        {
            throw new NotImplementedException();
        }

        public bool IsAlive()
        {
            throw new NotImplementedException();
        }
    }
}