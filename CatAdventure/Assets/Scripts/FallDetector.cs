using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public Life life;
    [SerializeField] private Transform playerObject;
    [SerializeField] private Transform checkPoint;

    public Transform CheckPoint
    {
        get { return checkPoint;}
        set { checkPoint = value;}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            playerObject.position = checkPoint.position;
            life.LifeNum--;
            life.ActiveLife();
        }
            
    }
}
