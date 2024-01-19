using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToVideoSwitch : MonoBehaviour
{
    [SerializeField] private GameObject menuSceneStuff;
    [SerializeField] private GameObject winScreen;

    [SerializeField] private GameObject QuestionCanvas;
    [SerializeField] private GameObject GamificationCanvas;

    [SerializeField] private GameObject questionDisplayBoard;
    [SerializeField] private GameObject questionAnswerBoard;

    [SerializeField] private GameObject wrongAnswerFeedback;
    [SerializeField] private GameObject correctAnswerFeedback;

    [SerializeField] private ScoreManager score;
    private void Start()
    {
        menuSceneStuff.SetActive(true);
        winScreen.SetActive(false);

        QuestionCanvas.SetActive(false);
        GamificationCanvas.SetActive(false);

        questionDisplayBoard.SetActive(true);
        questionAnswerBoard.SetActive(false);

        wrongAnswerFeedback.SetActive(false);
        correctAnswerFeedback.SetActive(false);
    }

    public void Switch()
    {
        QuestionCanvas.SetActive(true);
        GamificationCanvas.SetActive(true);

        menuSceneStuff.SetActive(false);
    }

    public void Win()
    {
        winScreen.SetActive(true);

        QuestionCanvas.SetActive(false);
        GamificationCanvas.SetActive(false);

        score.PausedVideo(false);
    }
}