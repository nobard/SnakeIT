using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject enlargingImg;

    void Update(){
        if(Input.GetMouseButtonDown(0))
            enlargingImg.SetActive(false);
    }
}