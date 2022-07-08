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
            return;
        instance = this;
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

    public void TestLoadScene()
    {
        SceneManager.LoadScene("02.Map");
        mapState = MapState.Forest;
    }
}
