using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopSorter : MonoBehaviour
{
    public GameObject Student;

    public List<GameObject> students;

    void Start(){
        for(var i = 8; i > -1; i--){
            var studPlace = Student.GetComponent<TopMenu>().siblingIndex;
            var fakeStudPlace = students[i].GetComponent<TopMenu>().siblingIndex;
            var studPoints = PlayerPrefs.GetInt("PlayerPoints");
            if(studPoints >= students[i].GetComponent<TopMenu>().fakeStudentPoints){
                Student.GetComponent<TopMenu>().siblingIndex = fakeStudPlace;
                Student.GetComponent<TopMenu>().studentPlace.text = (fakeStudPlace + 1).ToString();
                students[i].GetComponent<TopMenu>().siblingIndex = studPlace;
                students[i].GetComponent<TopMenu>().studentPlace.text = (studPlace + 1).ToString();
                Student.transform.SetSiblingIndex(fakeStudPlace);
                students[i].transform.SetSiblingIndex(studPlace);
            }
        }
    }
}