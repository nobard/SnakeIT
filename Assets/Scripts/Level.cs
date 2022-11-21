using System.Collections;
using System.Collections.Generic;
using IEnumerator = System.Collections.IEnumerator;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Text;

public class Level : MonoBehaviour
{
    public GameObject PointChecker1;

    public GameObject PointChecker2;

    public GameObject PointChecker3;

    public GameObject PointChecker4;

    public GameObject CompleteMenuUI;

    public GameObject LoseMenuUI;

    public GameObject Apple;

    public GameObject Stone;

    int sceneIndex;

    string levelComplete;

    private int winPoints;

    private bool levelFlag = false;

    public int PlayerLives = 3;

    void Start(){
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetString("LevelComplete");
    }

    public void SetFoodActive(){
        Apple.SetActive(true);
        Stone.SetActive(true);
    }

    void Update()
    {
        if(PointChecker1.GetComponent<PointChecker>().CardPlacedCorrect && 
            PointChecker2.GetComponent<PointChecker>().CardPlacedCorrect && 
            PointChecker3.GetComponent<PointChecker>().CardPlacedCorrect &&
            PointChecker4.GetComponent<PointChecker>().CardPlacedCorrect){
                if(!levelFlag){
                    CompleteMenuUI.GetComponent<LiteLives>().ChangeLives(PlayerLives, CountPlayerPoints(), winPoints);
                    levelFlag = true;
                }
                StartCoroutine("Delay"); 
            }
        if(PlayerLives == 0)
            LoseMenuUI.SetActive(true);
    }

    private int CountPlayerPoints(){
        var currentPlayerPoints = PlayerPrefs.GetInt("PlayerPoints");
        winPoints = 0;
        var completeLevels = PlayerPrefs.GetString("LevelComplete").Split(',');
        var levelPoints = PlayerPrefs.GetString("LevelsPoints").Split(';');
        var flagComLvl = false;
        print(PlayerPrefs.GetString("LevelsPoints"));
        print(PlayerPrefs.GetString("LevelComplete"));
        if(completeLevels.Length > 1){
            if(Int32.TryParse(completeLevels[completeLevels.Length - 2], out int lastLevel)){
                if(lastLevel >= sceneIndex){
                    flagComLvl = true;
                    if(Int32.TryParse(levelPoints[sceneIndex - 1], out int alreadyPoints)){
                        print("ok");
                        if(PlayerLives == 3)
                            winPoints = 300 - alreadyPoints;
                        if(PlayerLives == 2)
                            winPoints = 200 - alreadyPoints;
                        if(PlayerLives == 1)
                            winPoints = 100 - alreadyPoints;
                        if(winPoints < 0)
                            winPoints = 0;
                    }
                }
                else
                {
                    winPoints = PlayerLives * 100;
                }
            }
        }
        else
        {
            winPoints = PlayerLives * 100;
        }
        if(!flagComLvl){
            levelComplete += sceneIndex.ToString() + ",";
            PlayerPrefs.SetString("LevelComplete", levelComplete);
        }
        PlayerPrefs.SetInt("PlayerPoints", winPoints + currentPlayerPoints);


        var gettedPoints = "";
        if(completeLevels.Length > 1){
            if(Int32.TryParse(levelPoints[sceneIndex - 1], out int points)){
                levelPoints[sceneIndex - 1] = (points + winPoints).ToString();
                print("ok2");
            }
            else{
                levelPoints[sceneIndex - 1] = winPoints.ToString();
            }
            if(flagComLvl){
                gettedPoints = String.Join(";", levelPoints);
            }
            else{
                gettedPoints = String.Join(";", levelPoints) + ";";
            }
        }
        else
        {
            gettedPoints = winPoints.ToString() + ";";
        }


        PlayerPrefs.SetString("LevelsPoints", gettedPoints);
        return currentPlayerPoints;
    }

    IEnumerator Delay(){
        yield return new WaitForSeconds(2.9f);
        CompleteMenuUI.SetActive(true);
    }
}