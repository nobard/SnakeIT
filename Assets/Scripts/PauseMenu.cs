using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public GameObject theoryMenuUI;

    public GameObject Snake;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Theory(){
        theoryMenuUI.SetActive(true);
        theoryMenuUI.GetComponent<Hints>().Hint1.SetActive(true);
        try{
            theoryMenuUI.GetComponent<Hints>().Hint2.SetActive(false);
        }
        catch{
            print("kk");
        }

        try{
            theoryMenuUI.GetComponent<Hints>().Hint3.SetActive(false);
        }
        catch{
            print("kk");
        }
    }
}
