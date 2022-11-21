using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointChecker : MonoBehaviour
{
    public int QueueOfPoint; 

    public bool CardPlacedCorrect = false;

    public GameObject Snake;

    private bool CanPlacedOnPoint;

    public GameObject Cards;

    private bool mousePressed = false;

    void Update(){
        if (Input.GetMouseButton(0))
            mousePressed = true;
        else
            mousePressed = false;
    }

    void OnTriggerStay2D(Collider2D card){
        card.GetComponent<EnlargeCard>().CardIsHoldingMethod(true);
        if (!mousePressed)
            if(!CardPlacedCorrect){
                if((QueueOfPoint == 1 || QueueOfPoint == 2) && 
                    (card.GetComponentInParent<InventoryElement>().QueueOfObject == 1 || card.GetComponentInParent<InventoryElement>().QueueOfObject == 2)){
                        CorrectAnswer(card);
                }
                else if(card.GetComponentInParent<InventoryElement>().QueueOfObject == QueueOfPoint){
                    CorrectAnswer(card);
                }
                else
                    InCorrectAnswer(card);
                GetComponentInParent<Level>().SetFoodActive();
            }
    }

    void OnTriggerExit2D(Collider2D card){
        card.GetComponent<EnlargeCard>().CardIsHoldingMethod(false);
    }

    void CorrectAnswer(Collider2D card){
        CardPlacedCorrect = true;
        card.GetComponentInParent<InventoryElement>().CardPlaced = true;
        card.GetComponent<EnlargeCard>().cardElement.transform.position = this.transform.position;
        card.GetComponentInParent<InventoryElement>().MovePosibility = false;
        Cards.GetComponent<AllCardsCanMove>().AllCardsMovePosibility = false;
        Snake.GetComponent<SnakeKeyboardInputHandler>().CorrectCardPlaced();
    }

    void InCorrectAnswer(Collider2D card){
        card.GetComponentInParent<InventoryElement>().CardPlaced = true;
        card.GetComponent<EnlargeCard>().cardElement.transform.position = this.transform.position;
        card.GetComponentInParent<InventoryElement>().MovePosibility = false;
        Cards.GetComponent<AllCardsCanMove>().AllCardsMovePosibility = false;
        Snake.GetComponent<SnakeKeyboardInputHandler>().InCorrectCardPlaced();
        card.GetComponentInParent<InventoryElement>().PlaceCardToStart();
    }
}