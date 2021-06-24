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

        public void StartWave()
        {
                StartCoroutine(SpawnWave());
        }

        private IEnumerator SpawnWave()
        {
                int monsterIndex = Random.Range(0, 4);
                string type = string.Empty;
                switch (monsterIndex)
                {
                        case 0:
                                type = "EnemyBandit";
                                break;
                        case 1:
                                type = "EnemySimple";
                                break;
                        case 2:
                                type = "EnemyTank";
                                break;
                }

                Pool.GetObject(type);
                
                yield return new WaitForSeconds(2.5f);
        }


}
