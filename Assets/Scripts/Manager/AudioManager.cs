using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public enum AudioChannel
    {
        Bgm,
        Sfx,
    }

    public float sfxVolumePercent { get; private set;}
    public float bgmVolumePercent { get; private set; }

    AudioSource sfxSource;
    AudioSource musicSources;
    int activeMusicSourceIndex;

    SoundLibrary library;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            library = GetComponent<SoundLibrary>();

            GameObject newMusicSource = new GameObject("Music Source ");
            musicSources = newMusicSource.AddComponent<AudioSource>();
            newMusicSource.transform.parent = transform;

            GameObject newSfxSource = new GameObject("sfx source");
            sfxSource = newSfxSource.AddComponent<AudioSource>();
            newSfxSource.transform.parent = transform;

            bgmVolumePercent =  PlayerPrefs.GetFloat("bgm vol", 1);
            sfxVolumePercent =  PlayerPrefs.GetFloat("sfx vol", 1);
        }
    }

    //음량 조절
    public void SetVolume(float volumePercent, AudioChannel channel)
    {
        switch(channel)
        {
            case AudioChannel.Bgm:
                bgmVolumePercent = volumePercent;
                break;
            case AudioChannel.Sfx:
                sfxVolumePercent = volumePercent;
                break;
        }

        musicSources.volume = bgmVolumePercent;
        sfxSource.volume = sfxVolumePercent;

        PlayerPrefs.SetFloat("bgm vol", bgmVolumePercent);
        PlayerPrefs.SetFloat("sfx vol", sfxVolumePercent);
    }

    //비지엠 출력
    public void PlayMusic(AudioClip clip, float fadeDuration = 1)
    {
        activeMusicSourceIndex = 1 - activeMusicSourceIndex;
        musicSources.clip = clip;
        musicSources.loop = true;
        musicSources.Play();

        StartCoroutine(AnimateMusicCrossfade(fadeDuration));
    }

    //이름으로 라이브러리에 있는 효과음 찾기 --> 효과음 제작되면 라이브러리에 넣기
    public void PlaySound(string soundName)
    {
        sfxSource.PlayOneShot(library.GetClipFromName(soundName), sfxVolumePercent);
    }

    IEnumerator AnimateMusicCrossfade(float duration)
    {
        float percent = 0;

        while(percent<1)
        {
            percent += Time.deltaTime * 1/duration;
            musicSources.volume = Mathf.Lerp(0, bgmVolumePercent, percent);
            yield return null;
        }
    }
}
