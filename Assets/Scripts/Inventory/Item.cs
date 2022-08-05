using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public SkillItemObject skillItemObject;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.PlaySound("item_01");
        if (collision.tag == "Player")
        {
            bool wasPickedUp = Inventory.instance.Add(skillItemObject, amount);

            if(wasPickedUp)
            {
                Destroy(gameObject);
            }            
        }        
    }

    private void OnApplicationQuit()
    {
        skillItemObject.amount = 0;
    }
}
