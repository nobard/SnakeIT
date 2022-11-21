using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theory : MonoBehaviour
{
    public GameObject TheoryMenu;

    public GameObject Theory1;

    public GameObject Theory2;

    public GameObject Theory3;

    public GameObject Theory4;

    public void Next1()
    {
        Theory1.SetActive(false);
        Theory2.SetActive(true);
    }

    public void Next2()
    {
        Theory2.SetActive(false);
        Theory3.SetActive(true);
    }

    public void Next3()
    {
        Theory3.SetActive(false);
        Theory4.SetActive(true);
    }

    public void Back1()
    {
        Theory2.SetActive(false);
        Theory1.SetActive(true);
    }

    public void Back2()
    {
        Theory3.SetActive(false);
        Theory2.SetActive(true);
    }

    public void Back3()
    {
        Theory4.SetActive(false);
        Theory3.SetActive(true);
    }

    public void Close()
    {
        TheoryMenu.SetActive(false);
    }
}
