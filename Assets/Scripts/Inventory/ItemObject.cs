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
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;

}
