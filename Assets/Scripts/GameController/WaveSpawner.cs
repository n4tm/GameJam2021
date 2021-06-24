using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameController
{
    public class WaveSpawner : MonoBehaviour
    {
        public static int enemiesAlive = 0;
        public Wave[] Waves;
        public Transform spawnPoint;
    
        public float timeBetweenWaves = 5f;
        private float countdown = 2f;

        public Text waveCountdownText;

        private int waveIndex = 0;
        void Update()
        {
            if (enemiesAlive > 0)
            {
                return;
            }
        
        
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }

            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
            waveCountdownText.text = Mathf.Floor(countdown).ToString();
        }
    
        IEnumerator SpawnWave()
        {
            Wave wave = Waves[waveIndex];
            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
            waveIndex++;
        
        }

        void SpawnEnemy(GameObject enemy)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint .rotation, transform);
            enemiesAlive++;
        }
    }
}
