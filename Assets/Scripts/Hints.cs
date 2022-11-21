using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public GameObject HintsMenu;

    public GameObject Hint1;

    public GameObject Hint2;

    public GameObject Hint3;

    public void Next1()
    {
        Hint1.SetActive(false);
        Hint2.SetActive(true);
    }

    public void Next2()
    {
        Hint2.SetActive(false);
        Hint3.SetActive(true);
    }

    public void Next()
    {
        HintsMenu.SetActive(false);
    }
}
