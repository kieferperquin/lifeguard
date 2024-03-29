using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class AnswerCheck : MonoBehaviour
{
    [SerializeField] private GameObject wrongAnswerFeedback;
    [SerializeField] private GameObject CorrectAnswerFeedback;

    [SerializeField] private QuestionHandeler functionQuestionHandeler;
    [SerializeField] private VideoClipCycle functionVideoClipCycle;
    [SerializeField] private ScoreManager functionScoreManager;

    [SerializeField] private WrongFeedbackHandler functionWrongAnswerHandler;
    [SerializeField] private CorrectFeedbackHandler functionCorrectAnswerHandler;

    [SerializeField] private Text debug;
    public void CheckAnswer(GameObject button)
    {
        if (button.CompareTag("Correct"))
        {
            functionScoreManager.ChangeIsAnswering(false);
            CorrectAnswerFeedback.SetActive(true);
            functionCorrectAnswerHandler.SetCorrectAnswerFeedback();
        }
        else if (button.CompareTag("Wrong")) // if wrong button is clicked start again for now but there should pop up a menu that will explain why it is wrong
        {
            functionScoreManager.ChangeIsAnswering(false);
            wrongAnswerFeedback.SetActive(true);
            functionWrongAnswerHandler.SetWrongAnswerFeedback();
        }
    }

    public void Wrong()
    {
        SceneManager.LoadScene(0);
    }

    public void Correct()
    {
        CorrectAnswerFeedback.SetActive(false);
        functionQuestionHandeler.SetNextQuestion();
        functionVideoClipCycle.PlayClip();
    }
}