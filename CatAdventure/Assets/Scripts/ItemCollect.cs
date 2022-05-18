using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
        if(null != player)
        {
            Destroy(gameObject);
        }
    }
}
