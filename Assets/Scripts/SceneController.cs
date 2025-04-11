using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private AudioClip theme, levelEndsSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToNextLevel(){
        if (levelEndsSound != null) {
            GameManager.Instance.audioManager.StopMusic();
            GameManager.Instance.audioManager.PlaySound(levelEndsSound);
        }
        GameManager.Instance.GoToNextLevel();
    }

    /*void OnGUI() {
        if (GUI.Button(new Rect(10, 10, 90, 20), "Skip Level"))
            GoToNextLevel();
        }*/
}
