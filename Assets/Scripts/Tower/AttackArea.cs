using UnityEngine;

namespace Tower
{
    public class AttackArea : MonoBehaviour
    {
        private CircleCollider2D RadiusCircle;
        [SerializeField] private GameObject TowerFun;
        [SerializeField] private SpriteRenderer Renderer;
        private float Radius;

        public void Start()
        {
            Renderer = gameObject.GetComponent<SpriteRenderer>();
            RadiusCircle = TowerFun.GetComponent<CircleCollider2D>();
            Radius = RadiusCircle.radius;

            Renderer.transform.localScale = Vector3.one;

            Renderer.transform.localScale += Vector3.one * 2 * Radius * Mathf.PI / 4;
        }
        public void ShowCircle()
        {
            Renderer.enabled = true;
        }

        public void HideCircle()
        {
            Renderer.enabled = false;
        }
    }
}
