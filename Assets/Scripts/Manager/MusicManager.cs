using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip bgm_Login;
    public AudioClip bgm_Forest;

    Coroutine amb_01;
    Coroutine amb_02;

    private void Start()
    {
        
    }

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
                StartCoroutine(CoStartAmbient_01());
                StartCoroutine(CoStartAmbient_02());
                break;

            case MapManager.MapState.Login:
                AudioManager.instance.PlayMusic(bgm_Login, 2);
                AudioManager.instance.StopSound();
                if(amb_01 != null && amb_02 != null)
                {
                    StopCoroutine(amb_01);
                    StopCoroutine(amb_02);
                }
                
                break;
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public IEnumerator CoStartAmbient_01()
    {
        yield return null;
        int second01 = Random.Range(180, 200);
        amb_01 = StartCoroutine(CoPlayAmbient_01(second01));
    }

    public IEnumerator CoStartAmbient_02()
    {
        yield return null;
        int second02 = Random.Range(12, 18);
        amb_02 = StartCoroutine(CoPlayAmbient_02(second02));
    }

    public IEnumerator CoPlayAmbient_01(float second)
    {
        yield return new WaitForSeconds(second);
        AudioManager.instance.PlayAmbientSound("amb_wind_01");
        StartCoroutine(CoStartAmbient_01());
    }

    public IEnumerator CoPlayAmbient_02(float second)
    {
        yield return new WaitForSeconds(second);
        AudioManager.instance.PlayAmbientSound("amb_wind_02");
        StartCoroutine(CoStartAmbient_02());
    }
}
