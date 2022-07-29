using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    #region Singleton
    public static MapManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    public enum MapState
    {
        Login,
        Forest,
        Dessert,
    }

    public MapState mapState;

     public void InventoryInit()
     {
        switch(mapState)
        {
            case MapState.Forest:
                ForestInventoryInit();
                break;
        }
     }

    public void ForestInventoryInit()
    {
        if(Inventory.instance != null)
            Inventory.instance.space = 1;
    }
}
