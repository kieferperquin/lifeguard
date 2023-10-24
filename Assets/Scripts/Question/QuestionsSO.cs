using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Questions")]
public class QuestionsSO : ScriptableObject
{
    // set the question the correct answer and then multiple wrong answers

    public string question;

    public string correctAnswer;

    public string[] wrongAnswers;
}