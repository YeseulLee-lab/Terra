using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemSlot : MonoBehaviour
{
    public TextMeshProUGUI amounText;
    public int amount;
    public Image icon;

    Item item;

    public void AddItem(int _amount, Item newItem)
    {
        amount = _amount;
        amounText.text = amount.ToString();
        item = newItem;
        icon.sprite = item.itemObject.icon;
        icon.enabled = true;
    }
}
