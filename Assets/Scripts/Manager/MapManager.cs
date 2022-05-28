using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Forest,
        Dessert,
    }

    public MapState mapState;

    public void Init()
    {
        switch(mapState)
        {
            case MapState.Forest:
                ForestInit();
                break;
        }
    }

    public void ForestInit()
    {
        Inventory.instance.space = 1;
    }
}
