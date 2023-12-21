using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongFeedbackHandler : MonoBehaviour
{
    [SerializeField] private QuestionHandeler function;
    [SerializeField] private Text whyCorrectAnswerText;
    public void SetWrongAnswerFeedback()
    {
        whyCorrectAnswerText.text = function.GiveQuestionsData().wrongAnswerFeedBack;
    }
}
