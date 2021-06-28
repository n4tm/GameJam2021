using Enemy;
using GameController;
using Magic;
using UnityEngine;

namespace Tower
{
    public class Projectile : MonoBehaviour
    {
        private CreateMagic gameMagic;
        private TowerAttack towerAttack;
        private GameObject target;
        [HideInInspector] public bool stun;
        [HideInInspector] public float stunTime;

        private void Update()
        {
            if (!target.activeInHierarchy)
            {
                GameManager.Instance.Pool.ReleaseObject(gameObject);
                return;
            }
            MoveToTarget();
        }

        public void Initialize(TowerAttack parent)
        {
            target = parent.target;
            towerAttack = parent;
        }

        private void MoveToTarget()
        {
            if (target != null && target.activeInHierarchy)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position,
                    Time.deltaTime * towerAttack.projectileSpeed*100);
                Vector2 dir = target.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyLife>().TakeDamage(towerAttack.damage);
                GameManager.Instance.Pool.ReleaseObject(gameObject);
                if (stun)
                {
                    other.GetComponent<EnemyMovement>().stunned = true;
                    other.GetComponent<EnemyMovement>().enemyStunTime = stunTime;
                    stun = false;
                }
            }
        }
    }
}
