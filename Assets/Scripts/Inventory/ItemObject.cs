using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    SkillItem,
}

public abstract class ItemObject : ScriptableObject
{ 
    public int uid;
    public Sprite icon;
    public bool isDefaultItem = false;
    public int amount;
    public ItemType type;
    [TextArea(3, 3)]
    public string description;

}
