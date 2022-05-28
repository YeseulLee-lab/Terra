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

    private void Start()
    {
        MapManager.instance.InventoryInit();
    }

    public bool Add(ItemObject itemObject, int amount)
    {
        if(!itemObject.isDefaultItem)
        {
            if(itemObejcts.Count >= space)
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
                itemObejcts.Add(itemObject);

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
}
