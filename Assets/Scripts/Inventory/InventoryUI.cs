using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public ItemSlot[] itemSlotArr;

    private void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallBack += UpdateUI;
        itemSlotArr = gameObject.transform.GetChild(0).gameObject.GetComponentsInChildren<ItemSlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < itemSlotArr.Length; i++)
        {
            if(i<inventory.itemObejcts.Count)
            {
                itemSlotArr[i].AddItem(inventory.itemObejcts[i]);
                itemSlotArr[i].amounText.text = inventory.itemObejcts[i].amount.ToString();
            }
            //È¹µæÇÑ ¾ÆÀÌÅÛ ¿ÜÀÇ ´Ù¸¥ Ä­ Å¬¸®¾î
            /*else
            {
                itemSlotArr[i].ClearSlot();
            }*/
        }
    }
}
