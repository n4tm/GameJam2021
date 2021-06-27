namespace GameController
{
    [System.Serializable]
    public class Wave
    {
        public readonly string[] enemyTypes = {"EnemyBandit", "EnemySimple", "EnemyTank"};
        public int count;
        public float rate;
    }
}
