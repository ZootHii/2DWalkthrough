using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static NewBehaviourScript Instance;
    public GameObject gameOverTrigger;
    public GameObject walls;
    public GameObject canvas;
    public GameObject eventSystem;
    public GameObject scoreController;
    public GameObject sceneController;

    private void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
        //DontDestroy();
    }

    public void DontDestroy()
    {
        DontDestroyOnLoad(gameOverTrigger);
        DontDestroyOnLoad(walls);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(eventSystem);
        DontDestroyOnLoad(scoreController);
        DontDestroyOnLoad(sceneController);
    }

    public void Destroy()
    {
        Destroy(gameOverTrigger);
        Destroy(walls);
        Destroy(canvas);
        Destroy(eventSystem);
        Destroy(scoreController);
        Destroy(sceneController);
    }
    
}
