using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    public Text Points;

    void Start(){
        var points = PlayerPrefs.GetInt("PlayerPoints");
            Points.text = points.ToString();
    }
}
