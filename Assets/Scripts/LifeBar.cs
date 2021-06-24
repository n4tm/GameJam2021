using GameController;
using Sounds;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    public int maxLife;
    public Transform lifeBar;
    private Vector3 lifeBarScale;
    [SerializeField] private int moneyDrop;
    public int actualLife;

    public float LifePercent { get; set; }

    void Start()
    {
        actualLife = maxLife;
        lifeBarScale = lifeBar.localScale;
        LifePercent = lifeBarScale.x / maxLife;
    }

    public void UpdateLifeBar()
    {
        if (actualLife <= 0) actualLife = 0;
        lifeBarScale.x = LifePercent*actualLife;
        lifeBar.localScale = lifeBarScale;
        if (actualLife <= 0)
        {
            GameManager.Instance.Pool.ReleaseObject(gameObject);
            FindObjectOfType<AudioManager>().Play("EnemyDead");
            WaveSpawner.enemiesAlive--;
            GameManager.Instance.EarnMoney(moneyDrop);
        }
    }
}
