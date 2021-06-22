using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private WayPoints wPoints;
    private int wayPointIndex;

    private void Start()
    {
        wPoints = GameObject.FindGameObjectWithTag("WayPoints").GetComponent<WayPoints>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wPoints.waypoints[wayPointIndex].position,speed * Time.deltaTime);

        if (Vector2.Distance(transform.position,wPoints.waypoints[wayPointIndex].position) < 0.1f)
        {
            if (wayPointIndex < wPoints.waypoints.Length - 1)
            {
                wayPointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }

            
        }
    }
    
}
