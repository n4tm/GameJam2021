using System.Collections.Generic;
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
