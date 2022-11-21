using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameObject Level;

    public GameObject Live1;

    public GameObject Live2;

    public GameObject Live3;

    void Update(){
        var lives = Level.GetComponent<Level>().PlayerLives;
        if(lives == 2)
            Live1.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
        if(lives == 1)
            Live2.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
        if(lives == 0)
            Live3.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
    }
}