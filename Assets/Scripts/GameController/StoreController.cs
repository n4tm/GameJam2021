using UnityEngine;

namespace GameController
{
    public class StoreController : MonoBehaviour
    {
        [SerializeField] private GameObject PanelStore;
        [SerializeField] private GameObject PanelMissPlace;
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
