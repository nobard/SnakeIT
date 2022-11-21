using UnityEngine;
using System.Collections;
using IEnumerator = System.Collections.IEnumerator;

public class Movement : MonoBehaviour {

    private Vector3 offset;

    public int QueueOfObject;

    public bool CardPlaced = false;

    public bool MovePosibility = true;

    private Vector3 StartPose;

    public GameObject Cards;

    public bool CanPlacedOnPoint = false;

    public bool CardHoldingOnPoint = false;

    void Start(){
        StartPose = this.transform.position;
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        //CanPlacedOnPoint = false;
    }

    void OnMouseUp(){
        //if(!CardPlaced && !CardHoldingOnPoint){
        if(!CardPlaced){
            this.transform.position = StartPose;
        }
        //CanPlacedOnPoint = true;
    }

    void OnMouseDrag()
    {
        if(MovePosibility && Cards.GetComponent<AllCardsCanMove>().AllCardsMovePosibility){
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

    public void PlaceCardToStart(){
        StartCoroutine(PlaceCardStart());
        MovePosibility = true;
    }

    IEnumerator PlaceCardStart(){
        yield return new WaitForSecondsRealtime(2.4f);
        this.transform.position = StartPose;
        CardPlaced = false;
    }
}