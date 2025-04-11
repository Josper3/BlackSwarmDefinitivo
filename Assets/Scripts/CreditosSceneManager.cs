using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
 public AudioClip mainMenuTheme;
    private void Start() 
    {
        if (mainMenuTheme != null)
        GameManager.Instance.audioManager.PlayMusic(mainMenuTheme);
    }

    public void VolverAtrás(){
        GameManager.Instance.ComeBack();
    }

    public void IrMenu(){
        GameManager.Instance.ToMenu();
    }
}
