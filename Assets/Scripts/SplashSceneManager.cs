using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSceneManager : MonoBehaviour 
{
    public AudioClip mainMenuTheme;
    public float waitTime = 8f;
    private float startedAt;
    private void Start() {
        //Debug.Log("SplashSceneManager Start()");
        if (mainMenuTheme != null){
            GameManager.Instance.audioManager.PlayMusic(mainMenuTheme);
            Debug.Log("No es nulo, lo lee!");

        }
        startedAt = Time.time;
    }
    /*void Update() {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Time.time - startedAt > waitTime)
        {
            Done();
        }
    }*/

    private bool doneCalled = false;

    void Update() {
        if (!doneCalled && (
            Input.anyKeyDown 
            || Input.GetMouseButtonDown(0) 
            || Input.GetMouseButtonDown(1) 
            || Time.time - startedAt > waitTime
        )) {
            doneCalled = true;
            Done();
        }
    }
    private void Done() {
        GameManager.Instance.GoToNextLevel(0);
    }
}