using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class AnswerCheck : MonoBehaviour
{
    [SerializeField] private Text debug;

    [SerializeField] private QuestionHandeler functionQuestionHandeler;
    [SerializeField] private VideoClipCycle functionVideoClipCycle;

    public void CheckAnswer(GameObject button)
    {
        if (button.CompareTag("Correct"))
        {
            functionQuestionHandeler.SetNextQuestion();
            functionVideoClipCycle.PlayClip();
        }
        else if (button.CompareTag("Wrong")) // if wrong button is clicked start again for now but there should pop up a menu that will explain why it is wrong
        {
            SceneManager.LoadScene(0);
        }
    }
}