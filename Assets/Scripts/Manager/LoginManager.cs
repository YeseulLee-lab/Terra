using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    #region Singleton
    public static LoginManager instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public Button ContinueButton;
    public Button ExitGameButton;
    public Button SettingButton;
    public Button NewGameButton;

    public GameObject mainMenuObject;
    public GameObject logoObject;
    public GameObject optionObject;

    public void Start()
    {
        //저장파일이 있다면 continuebutton setactive true
        NewGameButton.onClick.AddListener(LoadScene);
        ExitGameButton.onClick.AddListener(OnClickExitGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(optionObject.activeSelf)
            {
                optionObject.SetActive(false);
                mainMenuObject.SetActive(true);
                logoObject.SetActive(true);
            }
                
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("02.Map");
        MapManager.instance.mapState = MapManager.MapState.Forest;
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
