using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ItemSlot : MonoBehaviour
{
    public TextMeshProUGUI amounText;
    public ItemObject item;
    public int amount;

    private void Start()
    {
        amounText.text = amount.ToString();
    }

    public void updateAmount(int _amount)
    {
        amount = _amount;
        amounText.text = amount.ToString();
    }
}
