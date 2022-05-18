using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Light,
        Fire,
        Water,
    }

    public ItemType itemType;
    public int amount;
}
