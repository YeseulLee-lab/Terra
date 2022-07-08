using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Button saveButton;
    public Button quitButton;

    private void Start()
    {
        //세이브 버튼 addlistener 추가해야함.
        quitButton.onClick.AddListener(LoadLoginScene);
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);

        bgmSlider.value = AudioManager.instance.bgmVolumePercent;
        sfxSlider.value = AudioManager.instance.sfxVolumePercent;
    }


    public void LoadLoginScene()
    {
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
}
