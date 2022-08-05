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
        if (Input.GetKeyDown(KeyCode.R))
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

    public void Resume()
    {
        AudioManager.instance.PlaySound("ui_02");
        OptionObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        AudioManager.instance.PlaySound("ui_01");
        OptionObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RetryGame()
    {
        Player.transform.position = StartPoint.transform.position;
        int fullHealAmount = HeartHealthSystem.MAX_FRAGMENT_AMOUNT * HeartsHealthVisual.heartHealthSystemStatic.GetHeartList().Count;
        HeartsHealthVisual.heartHealthSystemStatic.Heal(fullHealAmount);
    }
}
