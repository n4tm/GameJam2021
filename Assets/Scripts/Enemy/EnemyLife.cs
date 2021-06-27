using GameController;
using UnityEngine;

namespace Enemy
{
    public class EnemyLife: MonoBehaviour
    {
        [SerializeField] private LifeBar lifeBar;

        public void TakeDamage(int damageAmount)
        {
            lifeBar.actualLife -= damageAmount;
            lifeBar.UpdateLifeBar();
        }
        
    }
}