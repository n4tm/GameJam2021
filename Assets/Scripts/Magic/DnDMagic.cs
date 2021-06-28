using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnDMagic : MonoBehaviour
{
    public float MagicDelay;
    private float MagicCooldown;
    public bool MagicCharged = true;
    
    private void Update()
    {
        if (!MagicCharged)
        {
            MagicCooldown += Time.deltaTime;
            if (MagicCooldown >= MagicDelay)
            {
                MagicCharged = true;
            } 
        }
    }

    private void OnMouseDown()
    {
        if (MagicCharged)
        {
            if (Input.mousePosition.x < 530)
            {
                //BetterTowers();
                Debug.Log("Magia de dano");
                MagicCharged = false;
            }

            if (Input.mousePosition.x > 530)
            {
                //BetterTowers();
                Debug.Log("Magia de buff");
                MagicCharged = false;
            }
        }
    }
}
