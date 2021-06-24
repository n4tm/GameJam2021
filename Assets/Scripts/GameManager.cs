using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
        public ObjectPool Pool { get; set; }

        private void Start()
        {
                Pool = gameObject.GetComponent<ObjectPool>();
        }
}
