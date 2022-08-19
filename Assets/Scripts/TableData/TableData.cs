using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TableData : MonoBehaviour
{
    #region Singleton
    public static TableData instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //테이블 데이터 가져오기 Init()
        MainDataInit();
        StringDataInit();
    }
    #endregion
}