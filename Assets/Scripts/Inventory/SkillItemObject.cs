using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Skill Item Object", menuName = "Inventory System/Items/Skill Item")]
public class SkillItemObject : ItemObject
{
    public enum SkillItemType
    {
        Water,
        Fire,
        Light,
    }

    public SkillItemType skillType;
    public void Awake()
    {
        type = ItemType.SkillItem;
    }
}
