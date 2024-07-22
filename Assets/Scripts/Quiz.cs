using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionScriptableObject question;
    [SerializeField] GameObject[] answerButtons = new GameObject[4];
    private void Start(){
        questionText.text = question.GetQuestion();

        //goes through all button objects, finds the first textmeshpro child component and prints the question answer at that array index on that button
        for (int i = 0; i < answerButtons.Length; i++){
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }

    }
}
