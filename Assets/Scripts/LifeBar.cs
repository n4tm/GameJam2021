using Enemy;
using GameController;
using Sounds;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private int moneyDrop;
    public int maxLife;
    public Transform lifeBar;
    public int actualLife;
    private WaveSpawner _waveSpawner;
    private EnemyMovement _enemyMovement;
    private Vector3 lifeBarScale;

    public float LifePercent { get; set; }

    void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _waveSpawner = GameObject.FindWithTag("GameController").GetComponent<WaveSpawner>();
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
            ResetEnemy();
        }
    }

    private void ResetEnemy()
    {
        gameObject.transform.position = _waveSpawner.spawnPoint.transform.position;
        _enemyMovement.wayPointIndex = 0;
        actualLife = maxLife;
        lifeBarScale.x = 13.36309f;
        LifePercent = lifeBarScale.x / maxLife;
        UpdateLifeBar();
    }
}
