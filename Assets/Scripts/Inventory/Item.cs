using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObject itemObject;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            bool wasPickedUp = Inventory.instance.Add(itemObject, amount);

            if(wasPickedUp)
            {
                Destroy(gameObject);
            }            
        }        
    }

    private void OnApplicationQuit()
    {
        itemObject.amount = 1;
    }
}
