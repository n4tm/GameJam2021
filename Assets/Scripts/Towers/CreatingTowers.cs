using System;
using GameController;
using Unity.Mathematics;
using UnityEngine;

namespace Towers
{
    public class CreatingTowers : MonoBehaviour
    {
        private DragDropTowers DropTowers;
        private GameObject NewTower;
        public GameObject[] Towers;
        public int TowerCounter;

        private void Start()
        {
            Towers = new GameObject[50];
        }

        public void CreateTower(GameObject TowerBuild)
        {
            
            DropTowers = TowerBuild.GetComponent<DragDropTowers>();
            NewTower = Instantiate(TowerBuild, DropTowers.TowerPos, Quaternion.identity);
            Towers[TowerCounter] = NewTower;
            TowerCounter++;
            NewTower.GetComponent<DragDropTowers>().enabled = false;
            NewTower.GetComponent<CircleCollider2D>().enabled = true;
            NewTower.transform.localScale = Vector3.one;
        }
    }
}
