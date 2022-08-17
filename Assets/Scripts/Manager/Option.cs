using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class Option : MonoBehaviour
{
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public Button audioButton;
    public Button saveButton;
    public Button quitButton;
    public Button initialButton;
    public Button cancelButton;

    public GameObject mainMenuObject;
    public GameObject logoObject;

    public GameObject AudioGroup;

    public GameObject popUpObject;
    public Text popUpText;
    public Button popUpYesButton;

    public TextMeshProUGUI masterVolumeNum;
    public TextMeshProUGUI bgmVolumeNum;
    public TextMeshProUGUI sfxVolumeNum;

    private void Start()
    {
        //세이브 버튼 addlistener 추가해야함.
        audioButton.onClick.AddListener(OnClickAudioButton);
        quitButton.onClick.AddListener(OnClickQuitButton);
        initialButton.onClick.AddListener(InitailizeVolume);
        cancelButton.onClick.AddListener(OnClickCancelButton);

        popUpYesButton.onClick.AddListener(LoadLoginScene);

        //일반 볼륨
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        masterSlider.onValueChanged.AddListener(ChangeMasterVolumeNum);
        //배경음
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);
        bgmSlider.onValueChanged.AddListener(ChangeBgmVolumeNum);
        //효과음
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSfxVolumeNum);

        masterSlider.value = AudioManager.instance.masterVolumePercent;
        masterVolumeNum.text = Mathf.CeilToInt(masterSlider.value * 10).ToString();

        bgmSlider.value = AudioManager.instance.bgmVolumePercent;
        bgmVolumeNum.text = Mathf.CeilToInt(bgmSlider.value * 10).ToString();

        sfxSlider.value = AudioManager.instance.sfxVolumePercent;
        sfxVolumeNum.text = Mathf.CeilToInt(sfxSlider.value * 10).ToString();

        EventSystem.current.SetSelectedGameObject(audioButton.gameObject);
    }

    public void Update()
    {
        if(MapManager.instance.mapState == MapManager.MapState.Login)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                AudioManager.instance.PlaySound("ui_02");
                OnClickCancelButton();
            }
        }
    }

    public void OnClickQuitButton()
    {
        AudioGroup.SetActive(false);
        popUpObject.SetActive(true);
        popUpText.text = "게임을 종료하시겠습니까?";
    }

    public void LoadLoginScene()
    {
        Time.timeScale = 1;
        MapManager.instance.mapState = MapManager.MapState.Login;
        SceneManager.LoadScene("01.Login");

        //임시: 아이템 개수 초기화
        for(int i = 0; i< Inventory.instance.itemObejcts.Count; i++)
        {
            Inventory.instance.itemObejcts[i].amount = 0;
        }
    }

    public void SetBgmVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Bgm);
    }

    public void SetSfxVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void InitailizeVolume()
    {
        masterSlider.value = 0.5f;
        bgmSlider.value = 0.5f;
        sfxSlider.value = 0.5f;
    }

    public void OnClickAudioButton()
    {
        popUpObject.SetActive(false);
        AudioGroup.SetActive(true);
    }

    public void OnClickCancelButton()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            if (MapManager.instance.mapState == MapManager.MapState.Login)
            {
                AudioManager.instance.PlaySound("ui_02");
                mainMenuObject.SetActive(true);
                logoObject.SetActive(true);
            }
            else
            {
                if(ControlManager.instance != null)
                {
                    ControlManager.instance.Resume();
                }    
            }
        }
    }

    public void ChangeMasterVolumeNum(float value)
    {
        masterVolumeNum.text =  Mathf.CeilToInt(value*10).ToString();
    }

    public void ChangeBgmVolumeNum(float value)
    {
        bgmVolumeNum.text = Mathf.CeilToInt(value * 10).ToString();
    }

    public void ChangeSfxVolumeNum(float value)
    {
        sfxVolumeNum.text = Mathf.CeilToInt(value * 10).ToString();
    }
}
