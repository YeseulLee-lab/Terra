using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public ItemSlot[] itemSlotArr;

    private void Start()
    {
        itemSlotArr = gameObject.transform.GetChild(0).gameObject.GetComponentsInChildren<ItemSlot>();
    }

    /*void UpdateUI()
    {
        for(int i = 0; i<itemSlotArr.Length; i++)
        {
            itemSlotArr[i].AddItem()
        }
    }*/
}
