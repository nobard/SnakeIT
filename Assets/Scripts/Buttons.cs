using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject CompleteMenuUI;

    public void LoadLevelsMenu(){
        SceneManager.LoadScene("LevelsMenu");
    }

    public void LoadSettingsMenu(){
        SceneManager.LoadScene("Settings");
        PlayerPrefs.DeleteAll();
    }

    public void LoadTopMenu(){
        SceneManager.LoadScene("TopMenu");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        CompleteMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}