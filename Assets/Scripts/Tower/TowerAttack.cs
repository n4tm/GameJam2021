using System;
using System.Collections.Generic;
using Sounds;
using UnityEngine;

namespace Tower
{
    public class TowerAttack : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private AudioManager audioManager;
        private Queue<Transform> targets = new Queue<Transform>();
        private Projectile newProjectile;
        
        private void FixedUpdate()
        {
            if (targets.Count != 0) newProjectile.SetTargetTransform(targets.Peek());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                targets.Enqueue(other.gameObject.transform);
                newProjectile = Instantiate(projectile, transform.position, Quaternion.identity, transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                targets.Dequeue();
            }
        }
    }
}
