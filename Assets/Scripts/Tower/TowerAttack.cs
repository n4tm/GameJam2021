using System.Collections.Generic;
using GameController;
using Sounds;
using UnityEngine;

namespace Tower
{
    public class TowerAttack : MonoBehaviour
    {
        [SerializeField] private string projectileType;
        public float projectileSpeed;
        [SerializeField] private AudioManager audioManager;
        [HideInInspector] public GameObject target;
        private Queue<GameObject> targets = new Queue<GameObject>();
        private bool canAttack = true;
        private float attackTimer;
        [SerializeField] private float attackCooldown;
        public int damage;
        

        private void FixedUpdate()
        {
            Attack();
            if (target != null && target.activeInHierarchy)
            {
                var targ = target.transform.position;
                targ.z = 0f;
                var objectPos = transform.parent.transform.position;
                targ.x -= objectPos.x;
                targ.y -= objectPos.y;
 
                var angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
                transform.parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
            }
        }

        private void Attack()
        {
            if (!canAttack)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackCooldown)
                {
                    canAttack = true;
                    attackTimer = 0;
                }
            }
            if (target == null && targets.Count > 0) target = targets.Dequeue();
            if (target != null && target.activeInHierarchy)
            {
                if (canAttack) Shoot();
                canAttack = false;
            }
        }

        private void Shoot()
        {
            Projectile projectile = GameManager.Instance.Pool.GetObject(projectileType).GetComponent<Projectile>();
            projectile.Initialize(this);
            projectile.transform.position = transform.position;

            audioManager.Play("MageTowerProjectile");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                targets.Enqueue(other.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                target = null;
            }
        }
    }
}
