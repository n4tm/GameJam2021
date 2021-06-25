using GameController;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private string enemyType;
        public GameObject enemy;
        public float spawnRate;

        private float nextSpawn = 0f;
    

        void Update()
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;

                SpawnEnemy();
            }
        }

        void SpawnEnemy()
        {
            GameManager.Instance.Pool.GetObject(enemyType);
        }
    }
}
