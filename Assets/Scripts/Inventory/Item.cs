using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public SkillItemObject skillItemObject;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            bool wasPickedUp = Inventory.instance.Add(skillItemObject, amount);

            if(wasPickedUp)
            {
                Destroy(gameObject);
            }            
        }        
    }

    private void Update()
    {
        UseItem();
    }

    public void UseItem()
    {
        switch (skillItemObject.skillType)
        {
            case SkillItemObject.SkillItemType.Light:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if(skillItemObject.amount > 0)
                        skillItemObject.amount--;
                }
                break;

            case SkillItemObject.SkillItemType.Fire:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (skillItemObject.amount > 0)
                        skillItemObject.amount--;
                }
                break;

            case SkillItemObject.SkillItemType.Water:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (skillItemObject.amount > 0)
                        skillItemObject.amount--;
                }
                break;
        }

        if (Inventory.instance.OnItemChangedCallBack != null)
            Inventory.instance.OnItemChangedCallBack.Invoke();
    }

    private void OnApplicationQuit()
    {
        skillItemObject.amount = 1;
    }
}
