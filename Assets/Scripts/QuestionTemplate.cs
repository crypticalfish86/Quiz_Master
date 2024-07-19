using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Question", fileName = "New Question")]
public class QuestionTemplate : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question here";



}
