using UnityEngine;

namespace GameController
{
    public class StoreController : MonoBehaviour
    {
        [SerializeField] private GameObject PanelStore;

        public void OpenStore()
        {
            if (!PanelStore.activeInHierarchy)
            {
                PanelStore.SetActive(true);
            }
            else
            {
                PanelStore.SetActive(false);
            }
        }
    }
}
