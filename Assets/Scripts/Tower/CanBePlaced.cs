using UnityEngine;

namespace Tower
{
    public class CanBePlaced : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        public bool canPlace = true;
        private void OnTriggerStay2D(Collider2D other)
        {
            _spriteRenderer = GetComponentInParent<SpriteRenderer>();
            if ((other.CompareTag("Tower") || other.CompareTag("Road")) && GetComponentInParent<DropAndDrag>().IsDragged)
            {
                _spriteRenderer.color = Color.red;
                canPlace = false;
            }
            else
            {
                _spriteRenderer.color = Color.white;
                canPlace = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _spriteRenderer = GetComponentInParent<SpriteRenderer>();
            _spriteRenderer.color = Color.white;
            canPlace = true;
        }
    }
}
