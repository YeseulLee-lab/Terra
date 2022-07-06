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

    public void Start()
    {
        //저장파일이 있다면 continuebutton setactive true
        NewGameButton.onClick.AddListener(LoadScene);
        ExitGameButton.onClick.AddListener(OnClickExitGame);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("02.Map");
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
