using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    string levelComplete;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;
    public Button level7;
    public Button level8;
    public Button level9;
    public Button level10;
    public Button level12;
    public Button level13;
    public Button level14;
    public Button level15;
    public Button level17;
    public Button level18;
    public Button level19;
    public Button level20;

    public void RunLevel(int level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        levelComplete = PlayerPrefs.GetString("LevelComplete");
    }

    void Update()
    {
        var levelArray = levelComplete.Split(',');
        for(var i = 0; i < levelArray.Length; i++)
        {
            var level = int.Parse(levelArray[i]);
            ChangeLevelToComplete(level);
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
        if(level == 6)
            level7.interactable = true;
        if(level == 7)
            level8.interactable = true;
        if(level == 8)
            level9.interactable = true;
        if(level == 9)
            level10.interactable = true;
        if(level == 11)
            level12.interactable = true;
        if(level == 12)
            level13.interactable = true;
        if(level == 13)
            level14.interactable = true;
        if(level == 14)
            level15.interactable = true;
        if(level == 16)
            level17.interactable = true;
        if(level == 17)
            level18.interactable = true;
        if(level == 18)
            level19.interactable = true;
        if(level == 19)
            level20.interactable = true;
    }
}