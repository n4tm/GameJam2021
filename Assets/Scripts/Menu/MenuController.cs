using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        public void EnterPlayMode()
        {
            SceneManager.LoadScene("Game");
        }

        public void EnterCredits()
        {
            SceneManager.LoadScene("Credits");
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
