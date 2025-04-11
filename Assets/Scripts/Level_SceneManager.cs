using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_SceneManager : MonoBehaviour
{
    public AudioClip mainMenuTheme;
    private void Start() 
    {
        if (mainMenuTheme != null)
        GameManager.Instance.audioManager.PlayMusic(mainMenuTheme);
    }

}
