using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWayPointIndex = 1;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWayPointIndex].transform.position,transform.position) < .1f)
        {
            if(currentWayPointIndex == 1)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            currentWayPointIndex = 1 - currentWayPointIndex;// flip it from 0 -> 1 or vice versa
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
    }
}
