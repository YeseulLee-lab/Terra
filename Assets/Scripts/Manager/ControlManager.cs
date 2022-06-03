using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    #region Singleton
    public static ControlManager instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public GameObject StartPoint;

    public void RetryGame()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            
        }
    }
}
