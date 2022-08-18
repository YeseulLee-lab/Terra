using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableData : MonoBehaviour
{
    #region Singleton
    public static TableData instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion


}