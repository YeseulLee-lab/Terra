using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemSlot : MonoBehaviour
{
    public TextMeshProUGUI amounText;
    public Image icon;

    ItemObject itemObject;

    public void AddItem(ItemObject newItemObject)
    {
        itemObject = newItemObject;
        icon.sprite = itemObject.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        itemObject = null;
        icon.sprite = null;
        icon.enabled = false;
    }

}
