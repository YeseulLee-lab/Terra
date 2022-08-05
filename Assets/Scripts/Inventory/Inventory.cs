using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;

    public int space = 3;

    public List<ItemObject> itemObejcts = new List<ItemObject>();

    private bool isUsingItem = false;

    private void Start()
    {
        MapManager.instance.InventoryInit();
    }

    public bool Add(ItemObject itemObject, int amount)
    {
        if(!itemObject.isDefaultItem)
        {
            if(itemObejcts.Count > space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            bool itemAlreadyInInven = false;

            foreach(ItemObject itemObjectInven in itemObejcts)
            {
                if(itemObjectInven.uid == itemObject.uid)
                {
                    itemObjectInven.amount += amount;
                    itemAlreadyInInven = true;
                }
            }
            if(!itemAlreadyInInven)
            {
                itemObejcts.Add(itemObject);
                itemObject.amount ++;
            }

            if (OnItemChangedCallBack != null)
                OnItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(ItemObject itemObject)
    {
        itemObejcts.Remove(itemObject);
        if (OnItemChangedCallBack != null)
            OnItemChangedCallBack.Invoke();
    }

    private void Update()
    {
        UseItem();
    }

    public void UseItem()
    {
        if(isUsingItem)
            return;

        foreach(SkillItemObject itemObject in itemObejcts)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if(itemObject.skillType == SkillItemObject.SkillItemType.Light)
                {
                    AudioManager.instance.PlaySound("item_02");
                    if (itemObject.amount > 0)
                    {
                        itemObject.amount--;
                        UseLightItem();
                        StartCoroutine(CoItemUserTimer());
                    }
                }
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (itemObject.skillType == SkillItemObject.SkillItemType.Fire)
                {
                    AudioManager.instance.PlaySound("item_03");
                    if (itemObject.amount > 0)
                        itemObject.amount--;
                }
                    
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (itemObject.skillType == SkillItemObject.SkillItemType.Water)
                {
                    AudioManager.instance.PlaySound("item_04");
                    if (itemObject.amount > 0)
                        itemObject.amount--;
                }
            }
        }

        if (Inventory.instance.OnItemChangedCallBack != null)
            Inventory.instance.OnItemChangedCallBack.Invoke();
    }

    public void UseLightItem()
    {
        PlayerMove player = ControlManager.instance.Player.GetComponent<PlayerMove>();
        player.DamageFlash();
        StartCoroutine(player.CoEnableDamage(0f, 3f));
    }

    public IEnumerator CoItemUserTimer()
    {
        isUsingItem = true;
        yield return new WaitForSeconds(3f);
        isUsingItem = false;
    }

}
