using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    public int life;
    public Transform lifeBar;
    public GameObject lifeBarObject;

    private Vector3 lifeBarScale;

    private float lifePercent;
    
    void Start()
    {
        lifeBarScale = lifeBar.localScale;
        lifePercent = lifeBarScale.x / life;
    }

    void UpdateLifeBar()
    {
        lifeBarScale.x = lifePercent / life;
        lifeBar.localScale = lifeBarScale;
    }
}
