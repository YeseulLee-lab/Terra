using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Option : MonoBehaviour
{
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public Button audioButton;
    public Button saveButton;
    public Button quitButton;
    public Button initialButton;

    public GameObject AudioGroup;

    public GameObject popUpObject;
    public Text popUpText;
    public Button popUpYesButton;

    private void Start()
    {
        //세이브 버튼 addlistener 추가해야함.
        audioButton.onClick.AddListener(OnClickAudioButton);
        quitButton.onClick.AddListener(OnClickQuitButton);
        initialButton.onClick.AddListener(InitailizeVolume);

        popUpYesButton.onClick.AddListener(LoadLoginScene);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);

        masterSlider.value = AudioManager.instance.masterVolumePercent;
        bgmSlider.value = AudioManager.instance.bgmVolumePercent;
        sfxSlider.value = AudioManager.instance.sfxVolumePercent;

        EventSystem.current.SetSelectedGameObject(audioButton.gameObject);
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
        masterSlider.value = 5;
        bgmSlider.value = 5;
        sfxSlider.value = 5;
    }

    public void OnClickAudioButton()
    {
        popUpObject.SetActive(false);
        AudioGroup.SetActive(true);
    }
}
