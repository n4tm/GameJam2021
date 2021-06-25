using UnityEngine;
using UnityEngine.UIElements;

namespace Tower
{
    public class CreateTower : MonoBehaviour
    {
        [SerializeField] public GameObject Tower;

        public void BuyIt(GameObject towerType, int price, int playerMoney)
        {
            if (playerMoney >= price)
            {
                playerMoney -= price;
                Vector3 MousePos = Input.mousePosition;
                var transformPosition = towerType.transform.position;
                transformPosition.x = MousePos.x;
                transformPosition.y = MousePos.y;
            }
        }
    }
}
