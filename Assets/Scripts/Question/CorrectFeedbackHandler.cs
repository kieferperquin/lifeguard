using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectFeedbackHandler : MonoBehaviour
{
    [SerializeField] private QuestionHandeler function;
    [SerializeField] private Text CorrectAnswerText;
    public void SetCorrectAnswerFeedback()
    {
        CorrectAnswerText.text = function.GiveQuestionsData().correctAnswerFeedBack;
    }
}
