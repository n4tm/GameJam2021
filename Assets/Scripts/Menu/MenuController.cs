using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void EnterPlayMode()
    {
        SceneManager.LoadScene("Game");
    }

    public void EnterConfiguration()
    {
        SceneManager.LoadScene("Configuration");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
