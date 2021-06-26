using TMPro;
using UnityEngine;

namespace GameController
{
        public class GameManager : Singleton<GameManager>
        {
                public ObjectPool Pool { get; set; }
                public GameObject gameOverUI;
                public GameObject victoryUI;
                public int money;
                private int lives;
                public static int Rounds;
                /*private bool GameIsOver = false;
        private bool Victory = false;*/
                [SerializeField] private TextMeshProUGUI moneyTxt;
                [SerializeField] private TextMeshProUGUI livesTxt;

                private void Start()
                {
                        Time.timeScale = 1;
                        lives = 100;
                        money = 300;
                        livesTxt.text = lives.ToString();
                        moneyTxt.text = money.ToString();
                        Pool = gameObject.GetComponent<ObjectPool>();
                        /*GameIsOver = false;
                Victory = false;*/
                        Rounds = 0;
                }

                void Update()
                {
                        if (lives <= 0)
                        {
                                Time.timeScale = 0;
                                EndGame();
                        }
                }

                void EndGame()
                {
                        // GameIsOver = true;
                        gameOverUI.SetActive(true);
                }

                public void VictoryGame()
                {
                        // Victory = true;
                        Time.timeScale = 0;
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
}
