using UnityEngine;
using UnityEngine.SceneManagement;


namespace GameController
{
    public class StoreController : MonoBehaviour
    {
        [SerializeField] private GameObject panelStore;

        public void ChangeScene(string LevelName)
        {
            SceneManager.LoadScene(LevelName);
        }

        public void OpenStore()
        {
            if (!panelStore.activeInHierarchy)
            {
                panelStore.SetActive(true);
            }
            else
            {
                panelStore.SetActive(false);
            }
        }
    }
}
