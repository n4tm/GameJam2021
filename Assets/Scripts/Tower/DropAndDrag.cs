using UnityEngine;

namespace Tower
{
    public class DropAndDrag : MonoBehaviour
    {
        // Puxando os outros Scripts
        public AttackArea _AttackArea;
        public CreatingTowers _cTowers;
        public CanBePlaced _canBePlaced;

        // Mover o objeto Pai com o filho
        public GameObject dadTower;
    
        // Posição inicial do bloco e final
        private Vector3 initialPos;
        public Vector3 finalPos;
    
        // Compra da torre
        public int _money ; 
        [SerializeField] private int TowerCost;
    
        // Boleanos para marcar se o item pode ser movido e está sendo movido
        public bool IsDraggable = true;
        [HideInInspector] public bool IsDragged { get; set; }
    

        private void Start()
        {
            initialPos = gameObject.transform.position;
        }

        private void Update()
        {
            if (IsDragged)
            {
                dadTower.transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        private void OnMouseOver()
        {
            if (IsDraggable && Input.GetMouseButtonDown(0))
            {
                IsDragged = true;
                _AttackArea.ShowCircle();
                for (int i = 0; i < _cTowers.count; i++)
                {
                    _cTowers.Towers[i].GetComponentInChildren<AttackArea>().ShowCircle();
                }
            }
        }

        private void OnMouseUp()
        {
            if (IsDragged && _money >= TowerCost && _canBePlaced.canPlace)
            {
                finalPos = gameObject.transform.position;
                
                _cTowers.NewTower(dadTower, finalPos);
                dadTower.transform.position = initialPos;
                _money -= TowerCost;
            }
            
            for (int i = 0; i < _cTowers.count; i++)
            {
                _cTowers.Towers[i].GetComponentInChildren<AttackArea>().HideCircle();
            }
            IsDragged = false;
            _AttackArea.HideCircle();
            dadTower.transform.position = initialPos;
        }
    }
}
