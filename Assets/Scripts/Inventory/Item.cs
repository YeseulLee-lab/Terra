using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObject itemObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            InventoryObject.instance.AddItem(itemObject, 1);
            Destroy(gameObject);
        }        
    }
}
