using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillItemType
{
    Water,
    Fire,
    Light,
}

[CreateAssetMenu(fileName = "New Skill Item Object", menuName = "Inventory System/Items/Skill Item")]
public class SkillItemObject : ItemObject
{
    public SkillItemType skillType;
    public void Awake()
    {
        type = ItemType.SkillItem;
    }
}
