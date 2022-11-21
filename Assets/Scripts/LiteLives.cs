using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IEnumerator = System.Collections.IEnumerator;

public class LiteLives : MonoBehaviour
{
    public GameObject Live1;

    public GameObject Live2;

    public GameObject Live3;

    public Text WinPoints;

    public Text PlayerPoints;

    public void ChangeLives(int lives, int playerPoints, int winPoints){
        WinPoints.text = winPoints.ToString();
        PlayerPoints.text = (winPoints + playerPoints).ToString();

        if(lives == 3)
            Live3.SetActive(true);
        if(lives == 2)
            Live2.SetActive(true);
        if(lives == 1)
            Live1.SetActive(true);
    }
}
