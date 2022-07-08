using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip bgm_Login;
    public AudioClip bgm_Forest;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch(MapManager.instance.mapState)
        {
            case MapManager.MapState.Forest:
                AudioManager.instance.PlayMusic(bgm_Forest, 2);
                break;

            case MapManager.MapState.Login:
                AudioManager.instance.PlayMusic(bgm_Login, 2);
                break;
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
