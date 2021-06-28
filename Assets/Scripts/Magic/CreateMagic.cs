using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CreateMagic : MonoBehaviour
{
    public float BonusSpeed = 1;
    public float BonusDamage = 1;

    private float MagicTimer;
    private bool MagicActivated;

    private void Update()
    {
        if (true);
    }

    private void BetterTowers()
    {
        
        BonusSpeed -= 1/4;
        BonusDamage += 1/4;
    }
}
