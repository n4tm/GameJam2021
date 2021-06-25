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
            pauseMenuObj.GetComponentInParent<RawImage>().enabled = !pauseMenuObj.GetComponentInParent<RawImage>().enabled;
            Time.timeScale = Time.timeScale == 0? 1: 0;;
            pauseMenuObj.SetActive(false);
            
        }
        public void PauseGame()
        {
            pauseMenuObj.GetComponentInParent<RawImage>().enabled = !pauseMenuObj.GetComponentInParent<RawImage>().enabled;
            pauseMenuObj.SetActive(!pauseMenuObj.activeSelf);
            Time.timeScale = Time.timeScale == 0? 1: 0;
        }
        public void BackToInitialScreen()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}