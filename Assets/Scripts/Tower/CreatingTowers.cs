using UnityEngine;

namespace Tower
{
    public class CreatingTowers : MonoBehaviour
    {
        public DropAndDrag _drop;
        private GameObject NewBuild;
        private SpriteRenderer _spriteRenderer;
        public GameObject[] Towers = new GameObject[50];
        public int count;
        
        public void NewTower(GameObject DadTower, Vector3 Pos)
        {
            NewBuild = Instantiate(DadTower, Pos, Quaternion.identity);
            NewBuild.GetComponentInChildren<DropAndDrag>().IsDraggable = false;
            NewBuild.GetComponentInChildren<CanBePlaced>().enabled = false;
            NewBuild.GetComponentInChildren<BoxCollider2D>().isTrigger = false;
            NewBuild.GetComponentInChildren<CircleCollider2D>().enabled = true;
            NewBuild.GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Towers[count] = NewBuild;
            count++;
            
            _spriteRenderer = GetComponentInParent<SpriteRenderer>();
            NewBuild.transform.localScale = Vector3.one;
        }
    }
}
