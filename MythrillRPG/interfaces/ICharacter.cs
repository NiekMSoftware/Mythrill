namespace MythrillRPG.interfaces
{
    public interface ICharacter
    {
        // Damage
        protected int ReceiveDamage(int damage);
        protected int DealDamage(int damage);

        // Combat options
        protected void Attack();
        protected void Defend();
        protected void Dodge();
        protected void Heal();
        protected void UltimateAttack();

        // Combat functions
        protected int TakePoints(int amountOfPoints);
        protected int GainPoints(int amountOfPoints);
    }
}