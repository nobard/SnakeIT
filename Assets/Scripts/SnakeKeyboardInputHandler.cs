using System.Collections;
using System.Collections.Generic;
using IEnumerator = System.Collections.IEnumerator;
using UnityEngine;

public class SnakeKeyboardInputHandler : MonoBehaviour
{
    private IObjectMover _objectMover;

    private bool SnakeIsMoving = false;

    private Vector3 SnakeStartPose;

    public GameObject Tale;

    private void Start()
    {
        _objectMover = GetComponent<IObjectMover>();
        SnakeStartPose = Tale.transform.position;
    }

    public void CorrectCardPlaced(){
        if(!SnakeIsMoving){
            _objectMover.MoveForward();
            SnakeIsMoving = true;
            StartCoroutine(CorrectAnswerDelay());
        }
    }

    public void InCorrectCardPlaced(){
        if(!SnakeIsMoving){
            _objectMover.MoveForward();
            SnakeIsMoving = true;
            StartCoroutine(InCorrectAnswerDelay());
        }
    }
    
    IEnumerator CorrectAnswerDelay(){
        yield return new WaitForSecondsRealtime(0.9f);
        _objectMover.Rotate(Quaternion.Euler(0, 0, 90));
        yield return new WaitForSecondsRealtime(0.4f);
        _objectMover.Rotate(Quaternion.Euler(0, 0, 0));
    }

    IEnumerator InCorrectAnswerDelay(){
        yield return new WaitForSecondsRealtime(0.9f);
        _objectMover.Rotate(Quaternion.Euler(0, 0, -90));
        yield return new WaitForSecondsRealtime(0.4f);
        _objectMover.Rotate(Quaternion.Euler(0, 0, 0));
    }

    IEnumerator StopSnake(){
        yield return new WaitForSecondsRealtime(0.6f);
        _objectMover.Stop();
        SnakeIsMoving = false;
        FindObjectOfType<AllCardsCanMove>().AllCardsMovePosibility = true;
    }

    public void MoveSnakeToStart(){
        gameObject.GetComponentInParent<Transform>().position = SnakeStartPose;
        StartCoroutine(StopSnake());
    }
}