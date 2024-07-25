using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeForQuestionGiven = 30f; 
    [SerializeField] float timeForAnswerViewing = 10f;
    
    public bool playerAnsweringQuestion = false;
    
    float timeLeft;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer(){
        timeLeft -= Time.deltaTime;//timer counts down in real time

        //if player is answering question when timer = 0 then switch to answer view timer or vice versa
        if (timeLeft <= 0 && playerAnsweringQuestion){
            playerAnsweringQuestion = false;
            timeLeft = timeForAnswerViewing;
        }
        else if (timeLeft <= 0 && !playerAnsweringQuestion){
            playerAnsweringQuestion = true;
            timeLeft = timeForQuestionGiven;
        }

        Debug.Log(timeLeft);
    }
}
