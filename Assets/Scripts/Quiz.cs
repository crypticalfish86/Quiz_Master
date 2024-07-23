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
        FillAnswerButtons(question);

    }

    //processes answer selection
    public void OnAnswerSelected(int index){

        Image buttonImage; //button image put up here for performance

        //if correct answer is clicked, then will inform player its correct, otherwise gives the player the correct answer
        if (index == correctAnswerIndex){
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerButtonSprite;
            buttonImage.color = new Color (255, 209, 148, 255);
        }
        else{
            string questionBoxRevalingcorrectAnswer = "Incorrect, correct answer was:\n" + question.GetAnswer(correctAnswerIndex);
            questionText.text = questionBoxRevalingcorrectAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerButtonSprite;
            buttonImage.color = new Color (255, 209, 148, 255);
        }
    }

    //goes through all button objects, finds the first textmeshpro child component and prints the question answer at that array index on that button
    private void FillAnswerButtons(QuestionScriptableObject question){
        for (int i = 0; i < answerButtons.Length; i++){
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }
}
