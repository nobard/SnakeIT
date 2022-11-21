using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    string levelComplete;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;
    public Button level6;
    public Button level7;
    public Button level8;
    public Button level9;

    public void RunLevel(int level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
    }

    void Start()
    {
        levelComplete = PlayerPrefs.GetString("LevelComplete");
        var levelArray = levelComplete.Split(',');
        for(var i = 0; i < levelArray.Length; i++)
        {
            int level;
            if(Int32.TryParse(levelArray[i], out level)){
                ChangeLevelToComplete(level);
            }
        }
    }

    void ChangeLevelToComplete(int level)
    {
        if(level == 1)
            level2.interactable = true;
        if(level == 2)
            level3.interactable = true;
        if(level == 3)
            level4.interactable = true;
        if(level == 4)
            level5.interactable = true;
        if(level == 5)
            level6.interactable = true;
        if(level == 6)
            level7.interactable = true;
        if(level == 7)
            level8.interactable = true;
        if(level == 8)
            level9.interactable = true;
    }
}
