using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameController.ButtonControllers
{
    
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuObj;
        [SerializeField] private Camera _camera;
        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            WaveSpawner.enemiesAlive = 0;
        }
        public void ResumeGame()
        {
            pauseMenuObj.GetComponentInParent<RawImage>().enabled = !pauseMenuObj.GetComponentInParent<RawImage>().enabled;
            Time.timeScale = Time.timeScale == 0? 1: 0;
            pauseMenuObj.SetActive(false);
            _camera.GetComponent<AudioSource>().UnPause();
        }
        public void PauseGame()
        {
            pauseMenuObj.GetComponentInParent<RawImage>().enabled = !pauseMenuObj.GetComponentInParent<RawImage>().enabled;
            pauseMenuObj.SetActive(!pauseMenuObj.activeSelf);
            Time.timeScale = Time.timeScale == 0? 1: 0;
            if (_camera.GetComponent<AudioSource>().isPlaying) _camera.GetComponent<AudioSource>().Pause();
            else _camera.GetComponent<AudioSource>().UnPause();
        }
        public void BackToInitialScreen()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}