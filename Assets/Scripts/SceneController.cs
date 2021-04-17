using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public InputField yourName;
    public static SceneController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        Debug.Log(yourName.text);
        PlayerPrefs.SetString("name", yourName.text);
        PlayerPrefs.DeleteKey("score");
        SceneManager.LoadScene("Level1");
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        //NewBehaviourScript.Instance.Destroy();
        
    }
    

    public void NextLevel(int level)
    {
        SceneManager.LoadScene($"Level{level}");
    }
}
