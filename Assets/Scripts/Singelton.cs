using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component {
private static T _instance;
public static T Instance {
    get 
    {
        if (_instance == null) {
            _instance = FindObjectOfType<T>();
            
            if (_instance == null) 
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                _instance = obj.AddComponent<T>();
            }
        }
        return _instance;
    }
}

//Objeto que vamos a utilizar un monton, sirve para que no se me destruya el game object al cambiar de escena
    public virtual void Awake() 
    {
        if (_instance == null) {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}