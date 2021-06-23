using Sounds;
using UnityEngine;

namespace Tower
{
    public class TowerAttack : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private AudioManager audioManager;
        private GameObject[] targets = new GameObject[100];
        private Projectile newProjectile;
        [HideInInspector] public int targetCont;
        

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Enemy") && newProjectile == null)
            {
                newProjectile = Instantiate(projectile, transform.position, Quaternion.identity, transform);
                audioManager.Play("MageTowerProjectile");
                targets[targetCont] = other.gameObject;
                newProjectile.SetTargetTransform(targets[targetCont].transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Enemy")) targetCont++;
        }
    }
}
