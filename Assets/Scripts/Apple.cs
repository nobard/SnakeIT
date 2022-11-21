using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameObject SnakeHead;
    void OnTriggerEnter2D(Collider2D snake){
        if(snake == SnakeHead.GetComponent<Collider2D>()){
            gameObject.SetActive(false);
            snake.GetComponent<SnakeKeyboardInputHandler>().MoveSnakeToStart();
        }
    }

    public void SetFoodActive(){
        gameObject.SetActive(true);
    }
}