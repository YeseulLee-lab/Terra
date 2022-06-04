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
    public GameObject Player;

    public GameObject OptionObject;
    public static bool GameIsPaused = false;

    private void Update()
    {
        Option();
        RetryGame();
    }

    public void Option()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        OptionObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        OptionObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RetryGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Player.transform.position = StartPoint.transform.position;
        }
    }
}
