using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class EnlargeCard : MonoBehaviour{
    public GameObject enlargingImg;
    
    private float doubleClickTimeLimit = 0.35f;

    bool clickedOnce = false;

    float count = 0f;

    public GameObject cardElement;

    public void CardIsHoldingMethod(bool flag){
        cardElement.GetComponent<InventoryElement>().cardIsHoldingOnChecker = flag;
    }

    void OnMouseDown(){
        StartCoroutine (ClickEvent ());
    }

    public IEnumerator ClickEvent(){
        if(!clickedOnce && count < doubleClickTimeLimit){
            clickedOnce = true;
        } 
        else {
            clickedOnce = false;
            yield break;
        }
        yield return new WaitForEndOfFrame();

        while(count < doubleClickTimeLimit){
            if(!clickedOnce){
                DoubleClick();
                count = 0f;
                clickedOnce = false;
                yield break;
            }
            count += Time.deltaTime;
            yield return null;
        }
        count = 0f;
        clickedOnce = false;
    }

    private void DoubleClick(){
        enlargingImg.SetActive(true);
        print("doubleClicked");
    }
}