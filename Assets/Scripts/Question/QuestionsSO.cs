using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(menuName = "Questions")]
public class QuestionsSO : ScriptableObject
{
    // everything a question needs

    public string question;

    public VideoClip videoClip;

    public bool allCorrect;

    public bool pointClick;

    public List<string> correctAnswerList = new List<string>();

    public List<string> wrongAnswerList = new List<string>();
}