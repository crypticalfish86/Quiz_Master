using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{

    //QuestionScriptableObject
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionScriptableObject question;
    [SerializeField] GameObject[] answerButtons = new GameObject[4];
    int correctAnswerIndex;

    //Sprites
    [SerializeField] Sprite defaultAnswerButtonSprite;
    [SerializeField] Sprite correctAnswerButtonSprite;

    private void Start(){

        questionText.text = question.GetQuestion();
        correctAnswerIndex = question.GetCorrectAnswerIndex();

        //goes through all button objects, finds the first textmeshpro child component and prints the question answer at that array index on that button
        for (int i = 0; i < answerButtons.Length; i++){
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }

    }

    //processes answer selection
    public void OnAnswerSelected(int index){

        //if correct answer is clicked, then will inform player its correct, otherwise gives the player the correct answer
        if (index == correctAnswerIndex){
            questionText.text = "Correct!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerButtonSprite;
        }
        else{
            string questionBoxRevalingcorrectAnswer = "Incorrect, correct answer was: " + question.GetAnswer(question.GetCorrectAnswerIndex());
            questionText.text = questionBoxRevalingcorrectAnswer;
            Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerButtonSprite;
        }
    }
}
