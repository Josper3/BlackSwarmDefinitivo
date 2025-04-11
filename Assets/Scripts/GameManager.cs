using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> 
{
    public AudioManager audioManager;

    [SerializeField] private Sprite[] escena;

    public override void Awake() 
    {
        base.Awake();
        audioManager = GetComponent<AudioManager>();
            //Debug.Log(audioManager);
            //Debug.Log("GameManager está en escena");

    }
    public float interLevelWaitTime = 3f;

    public void GoToNextLevel(float waitTime = -1) 
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) {
            Debug.Log("No hay más eceneas");
        } else {
            if (waitTime < 0) waitTime = interLevelWaitTime;
            Debug.Log("Siguiente escena!");
            StartCoroutine(WaitAndLoadNextScene(waitTime));
        }
    }


    private IEnumerator WaitAndLoadNextScene(float waitSeconds) 
    {
        //Sí me pasas un valor que sea menor que uno, espero el tiempo de 3 segundo que estaba esperando antes.
        if(waitSeconds<0)
        {
            waitSeconds = interLevelWaitTime;
        }

        yield return new WaitForSeconds(waitSeconds);

        //Carga siguiente escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }


    public int GetNumberOfLevels(){
        // There are two scenes that are not levels: Splash and MainMenu
        return SceneManager.sceneCountInBuildSettings - 2;
    }
    const int FIRST_LEVEL_INDEX = 2;
    const int CREDITOS_INDEX = 3;


    public void LoadLevel(int levelIndex) {
        SceneManager.LoadScene(FIRST_LEVEL_INDEX + levelIndex);
    }

    public void LoadCredits(){
        SceneManager.LoadScene(CREDITOS_INDEX);
    }

    public void ComeBack(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex-1);
    }

    public void ToMenu(){
        SceneManager.LoadScene(1);
    }
}