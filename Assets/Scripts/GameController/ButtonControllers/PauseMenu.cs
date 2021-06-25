using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameController.ButtonControllers
{
    
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuObj;
        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
            pauseMenuObj.SetActive(false);
            
        }
        public void PauseGame()
        {
            pauseMenuObj.SetActive(!pauseMenuObj.activeSelf);
            Time.timeScale = 0;
        }
        public void BackToInitialScreen()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}