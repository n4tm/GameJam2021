using UnityEngine;

namespace Enemy
{
    public class EnemyLife: MonoBehaviour
    {
        [SerializeField] private LifeBar lifeBar;

        public void TakeDamage(float damageAmount)
        {
            lifeBar.LifePercent -= damageAmount/10/lifeBar.maxLife;
            if (lifeBar.LifePercent < 0) lifeBar.LifePercent = 0;
            lifeBar.UpdateLifeBar();
        }
        
    }
}