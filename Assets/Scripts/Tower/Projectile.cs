using System;
using UnityEngine;

namespace Tower
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Transform targetTransform;

        public void SetTargetTransform(Transform newTargetTransform)
        {
            targetTransform = newTargetTransform;
        }
        
        private void Update()
        {
            if (targetTransform != null) Move();
        }

        private void Move()
        {
            var targetPosition = targetTransform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                // Diminuir HP do inimigo aqui
                Destroy(gameObject);
            }
        }
    }
}
