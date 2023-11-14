using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Questions")]
public class QuestionsSO : ScriptableObject
{
    // set the question the correct answer and then multiple wrong answers

    public string question;

    public bool allCorrect;

    public List<string> correctAnswerList = new List<string>();

    public List<string> wrongAnswerList = new List<string>();
}