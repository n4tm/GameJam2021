using Sounds;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    public int maxLife;
    public Transform lifeBar;
    private Vector3 lifeBarScale;

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
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("EnemyDead");
        }
    }
}
