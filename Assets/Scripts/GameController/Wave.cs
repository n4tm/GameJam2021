using UnityEngine;

namespace GameController
{
    [System.Serializable]
    public class Wave
    {
        public readonly string[] enemyTypes = new string[] {"EnemyBandit", "EnemySimple", "EnemyTank"};
        public int count;
        public float rate;
    }
}
