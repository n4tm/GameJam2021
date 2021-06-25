using System.Collections;
using TMPro;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
        public ObjectPool Pool { get; set; }
        public GameObject gameOverUI;
        public GameObject victoryUI;
        public int money;
        private int lives;
        public static int Rounds = 0;
        private bool GameIsOver = false;
        private bool Victory = false;
        [SerializeField] private TextMeshProUGUI moneyTxt;
        [SerializeField] private TextMeshProUGUI livesTxt;

        private void Start()
        {
                lives = 1;
                money = 500;
                livesTxt.text = lives.ToString();
                moneyTxt.text = money.ToString() + " <color=green>$</color>";
                Pool = gameObject.GetComponent<ObjectPool>();
                GameIsOver = false;
                Victory = false;
                Rounds = 0;
        }

        void Update()
        {
                if (lives <= 0)
                { 
                        EndGame();
                }
        }

        void EndGame()
        {
                GameIsOver = true;
                gameOverUI.SetActive(true);
        }

        public void VictoryGame()
        {
                Victory = true;
                victoryUI.SetActive(true);
        }
                 
        public void EarnMoney(int moneyAmount)
        {
                money += moneyAmount;
                moneyTxt.text = money.ToString();
        }

        public void SpendMoney(int moneyAmount)
        {
                money -= moneyAmount;
                moneyTxt.text = money.ToString();
        }
        public void LoseLives(int damageAmount)
        {
                lives -= damageAmount;
                livesTxt.text = lives.ToString();
        }

}
