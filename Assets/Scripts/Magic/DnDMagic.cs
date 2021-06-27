using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnDMagic : MonoBehaviour
{
    private CreateMagic cast;
    public GameObject Magic;
    
    private Vector3 initialPos;
    public Vector3 CastPoint;

    public float MagicDelay;
    private float MagicCooldown;
    public bool MagicCharged = true;
    public bool Dragged;


    private void Start()
    {
        initialPos = Magic.transform.position;
    }

    private void Update()
    {
        
        if (!MagicCharged)
        {
            MagicDelay += Time.deltaTime;
            if (MagicDelay >= MagicCooldown)
            {
                MagicCharged = true;
            } 
        }

        if (MagicCharged && Dragged)
        {
            Magic.transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        if (MagicCharged)
        {
            Dragged = true;
            Magic.gameObject.SetActive(true);
        }
    }

    private void OnMouseUp()
    {
        Dragged = false;
        MagicCharged = false;
        CastPoint = Magic.transform.position;
        
        cast.cast(DnDMagic.Instantiate(Magic), CastPoint);
        
        Magic.transform.position = initialPos;
        Magic.gameObject.SetActive(false);
    }
}
