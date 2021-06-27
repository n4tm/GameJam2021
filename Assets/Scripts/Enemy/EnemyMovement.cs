using System.Collections;
using GameController;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public float speed;
        private WayPoints wPoints;
        public int wayPointIndex;
        public bool stunned;
        [HideInInspector] public float enemyStunTime;
        [SerializeField] private int damageAmount;

        private void Start()
        {
            wPoints = GameObject.FindGameObjectWithTag("WayPoints").GetComponent<WayPoints>();
        }

        private void Update()
        {
            if (!stunned)
                transform.position = Vector2.MoveTowards(transform.position, wPoints.waypoints[wayPointIndex].position,
                    speed * Time.deltaTime);
            else StartCoroutine(Stun());
            if (Vector2.Distance(transform.position,wPoints.waypoints[wayPointIndex].position) < 0.1f)
            {
                if (wayPointIndex < wPoints.waypoints.Length - 1)
                {
                    wayPointIndex++;
                }
                else
                {
                    WaveSpawner.enemiesAlive--;
                    GameManager.Instance.Pool.ReleaseObject(gameObject);
                    GameManager.Instance.LoseLives(damageAmount);
                    GetComponent<LifeBar>().ResetEnemy();
                }
            }
        }

        IEnumerator Stun()
        {
            yield return new WaitForSeconds(enemyStunTime);
            stunned = false;
        }
    }
}
