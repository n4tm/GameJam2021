using UnityEngine;

namespace Tower
{
    public class TowerAttack : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private GameObject target;
        private Projectile newProjectile;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Enemy") && newProjectile == null)
            {
                newProjectile = Instantiate(projectile, transform.position, Quaternion.identity, transform);
                target = other.gameObject;
                newProjectile.SetTargetTransform(target.transform);
            }
        }
    }
}
