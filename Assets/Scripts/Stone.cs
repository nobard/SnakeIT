using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public GameObject SnakeHead;
    
    public GameObject Level;

    void OnTriggerEnter2D(Collider2D snake){
        if(snake == SnakeHead.GetComponent<Collider2D>()){
            Level.GetComponent<Level>().PlayerLives -= 1;
            gameObject.SetActive(false);
            snake.GetComponent<SnakeKeyboardInputHandler>().MoveSnakeToStart();
        }
    }

    public void SetFoodActive(){
        gameObject.SetActive(true);
    }
}