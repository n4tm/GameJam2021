using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace GameController
{
    public class WaveSpawner : MonoBehaviour
    {
        public TextMeshProUGUI IndexTxt;
        
        public static int enemiesAlive;
        public Wave[] Waves;
        public Transform spawnPoint;
    
        public float timeBetweenWaves = 5f;
        private float countdown = 2f;

        private int waveIndex;
        void Update()
        {
            if (enemiesAlive > 0)
            {
                return;
            }
            
            if (countdown <= 0f)
            {
                GameManager.Rounds++;
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }

            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        }
    
        IEnumerator SpawnWave()
        {
            Wave wave = Waves[waveIndex];
            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemyTypes[Random.Range(0, 3)]);
                yield return new WaitForSeconds(1f / wave.rate);
            }
            waveIndex++;
            IndexTxt.text = "Wave: " + waveIndex.ToString();
            if (waveIndex == Waves.Length)
            {
                GameManager.Instance.VictoryGame();
            }
            
        }

        public void SpawnEnemy(string enemyType)
        {
            GameObject obj = GameManager.Instance.Pool.GetObject(enemyType);
            obj.transform.position = spawnPoint.position;
            enemiesAlive++;
        }
    }
}
