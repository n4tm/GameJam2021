using UnityEngine;

namespace Enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        public GameObject enemy;
        public float spawnRate;

        private float nextSpawn = 0f;
    

        void Update()
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;

                Instantiate(enemy, transform.position, enemy.transform.rotation, transform);
            }
        }
    }
}
