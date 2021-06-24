using Sounds;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    public int maxLife;
    public Transform lifeBar;
    private Vector3 lifeBarScale;
    [SerializeField] private int moneyDrop;

    public float LifePercent { get; set; }

    void Start()
    {
        lifeBarScale = lifeBar.localScale;
        LifePercent = lifeBarScale.x / maxLife;
    }

    public void UpdateLifeBar()
    {
        lifeBarScale.x = LifePercent*maxLife;
        lifeBar.localScale = lifeBarScale;
        if (LifePercent <= 0)
        {
            GameManager.Instance.Pool.ReleaseObject(gameObject);
            FindObjectOfType<AudioManager>().Play("EnemyDead");
            WaveSpawner.enemiesAlive--;
            GameManager.Instance.EarnMoney(moneyDrop);
        }
    }
}
