using TMPro;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
        public ObjectPool Pool { get; set; }
        private int money;
        [SerializeField] private TextMeshProUGUI moneyTxt;

        private void Start()
        {
                money = 500;
                moneyTxt.text = money.ToString() + " <color=green>$</color>";
                Pool = gameObject.GetComponent<ObjectPool>();
        }

        public void EarnMoney(int moneyAmount)
        {
                money += moneyAmount;
                moneyTxt.text = money.ToString() + " <color=green>$</color>";
        }
        
}
