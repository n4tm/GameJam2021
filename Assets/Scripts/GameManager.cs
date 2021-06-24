using System.Collections;
using TMPro;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
        public ObjectPool Pool { get; set; }
        private int money;
        private int lives;
        [SerializeField] private TextMeshProUGUI moneyTxt;
        [SerializeField] private TextMeshProUGUI livesTxt;

        private void Start()
        {
                lives = 100;
                money = 500;
                livesTxt.text = lives.ToString();
                moneyTxt.text = money.ToString() + " <color=green>$</color>";
                Pool = gameObject.GetComponent<ObjectPool>();
        }

        public void EarnMoney(int moneyAmount)
        {
                money += moneyAmount;
                moneyTxt.text = money.ToString() + " <color=green>$</color>";
        }

        public void LoseLives(int damageAmount)
        {
                lives -= damageAmount;
                livesTxt.text = lives.ToString();
        }

}
