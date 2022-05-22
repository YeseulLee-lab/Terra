using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Item Object", menuName = "Inventory System/Items/Skill Item")]
public class SkillItemObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.SkillItem;
    }
}
