using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameController.ButtonControllers
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuObj;
        [SerializeField] private RawImage gameCanvasTransparency;
        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
            pauseMenuObj.SetActive(false);
            gameCanvasTransparency.enabled = false;
        }
        public void PauseGame()
        {
            gameCanvasTransparency.enabled = true;
            pauseMenuObj.SetActive(!pauseMenuObj.activeSelf);
            Time.timeScale = 0;
        }
        public void BackToInitialScreen()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}