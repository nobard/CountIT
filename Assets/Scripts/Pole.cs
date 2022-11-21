using System;
using IEnumerator = System.Collections.IEnumerator;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pole : MonoBehaviour
{
    public Text currentArea;

    public float levelArea;

    public float tempArea;

    public GameObject CompleteMenuUI;

    public static Pole instance = null;
    int sceneIndex;
    string levelComplete;

    void Start()
    {
        if(instance == null)
            instance = this;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetString("LevelComplete");
    }

    void Update()
    {
        if(Math.Abs(tempArea - levelArea) < 0.001)
        {
            levelComplete += sceneIndex.ToString() + ",";
            PlayerPrefs.SetString("LevelComplete", levelComplete);
            StartCoroutine("Delay");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
        CompleteMenuUI.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        tempArea += other.GetComponent<ObjectsArea>().Area / 100;
        AddNewArea(tempArea);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        tempArea -= other.GetComponent<ObjectsArea>().Area / 100;
        AddNewArea(tempArea);
    }

    public void CountEnlargeArea(float excessArea, float addArea)
    {
        tempArea += addArea / 100 - excessArea / 100 ;
        AddNewArea(tempArea);
    }

    void AddNewArea(float tempArea)
    {
        currentArea.text = String.Format("{0:0.00}", tempArea);
    }
}