using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using IEnumerator = System.Collections.IEnumerator;

public class InventoryElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int QueueOfObject;

    public bool CardPlaced = false;

    public bool MovePosibility = true;

    public GameObject Cards;

    public bool cardIsHoldingOnChecker = false;
    
    public Transform defaultParentTransform;

    public Transform dragParentTransform;

    public int siblingIndex;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(MovePosibility && Cards.GetComponent<AllCardsCanMove>().AllCardsMovePosibility)
            transform.SetParent(dragParentTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        try{
            if(MovePosibility && Cards.GetComponent<AllCardsCanMove>().AllCardsMovePosibility){
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 10.0f));
            }
        }
        catch{
            Debug.Log("Can't move");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(MovePosibility && Cards.GetComponent<AllCardsCanMove>().AllCardsMovePosibility && !cardIsHoldingOnChecker){
            transform.SetParent(defaultParentTransform);
            transform.SetSiblingIndex(siblingIndex);
        }
    }

    public void PlaceCardToStart(){
        StartCoroutine(PlaceCardStart());
        MovePosibility = true;
    }

    IEnumerator PlaceCardStart(){
        yield return new WaitForSecondsRealtime(2.4f);
        transform.SetParent(defaultParentTransform);
        transform.SetSiblingIndex(siblingIndex);
        CardPlaced = false;
    }
}
