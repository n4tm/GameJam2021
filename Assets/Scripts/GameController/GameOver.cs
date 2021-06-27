using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameController
{
    public class GameOver : MonoBehaviour
    {
        public Text roundsText;

        void OnEnable()
        {
            roundsText.text = (GameManager.Rounds-1).ToString();
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            WaveSpawner.enemiesAlive = 0;
        }

        public void Continue()
        {
        
        }
        public void Menu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
