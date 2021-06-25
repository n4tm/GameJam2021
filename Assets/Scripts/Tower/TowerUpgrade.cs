namespace Tower
{
    public class TowerUpgrade
    {
        public int Price { get; private set; }
        public int Damage { get; private set; }
        public float AttackCooldown { get; private set; }

        public TowerUpgrade(int price, int damage, float attackCooldown)
        {
            Price = price;
            Damage = damage;
            AttackCooldown = attackCooldown;
        }
    }
}
