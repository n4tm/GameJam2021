using System;
using Towers;
using UnityEngine;

namespace GameController
{
    public class DragDropTowers : MonoBehaviour
    {
        public CircleRender circleRender;
        private SpriteRenderer _circleRend;
        public CreatingTowers _CreatingTowers;
        public DragDropTowers DropTowers;
        public bool isDragable = true;
        public bool isDragged;
        private Vector3 initialPos;
        public Vector3 TowerPos;

        
        private void Start()
        {
            DropTowers = gameObject.GetComponent<DragDropTowers>();
            _circleRend = GetComponentInChildren<SpriteRenderer>();
            initialPos = transform.position;
        }

        private void Update()
        {
            if (isDragged)
                
                transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void OnMouseOver()
        {
            if (isDragable && Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < _CreatingTowers.TowerCounter; i++)
                {
                    _CreatingTowers.Towers[i].GetComponent<CircleRender>().ShowCircle();
                }
                isDragged = true;
                circleRender.ShowCircle();
            } 
        }

        private void OnMouseUp()
        {
            TowerPos = transform.position;
            circleRender.HideCircle();
            isDragged = false;
            for (int i = 0; i < _CreatingTowers.TowerCounter; i++)
            {
                _CreatingTowers.Towers[i].GetComponent<CircleRender>().HideCircle();
            }
            transform.position = initialPos;
            _CreatingTowers.CreateTower(gameObject);
        }
    }
}
