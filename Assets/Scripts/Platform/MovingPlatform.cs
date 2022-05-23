using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject movingPlatformParent;
    [SerializeField] private List<GameObject> wayPoints;
    [SerializeField] private float speed = 2f;
    private int currentWayPointIndex = 0;

    

    private void Start()
    {
        movingPlatformParent = gameObject.transform.parent.gameObject;

        int childCount = movingPlatformParent.transform.childCount;
        for(int i = 1; i<childCount;i++)
        {
            wayPoints.Add(movingPlatformParent.transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        if(Vector2.Distance(wayPoints[currentWayPointIndex].transform.position, transform.position) < .1f)
        {
            currentWayPointIndex++;
            if(currentWayPointIndex >= wayPoints.Count)
            {
                currentWayPointIndex = 0;
                
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, 
                    wayPoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
