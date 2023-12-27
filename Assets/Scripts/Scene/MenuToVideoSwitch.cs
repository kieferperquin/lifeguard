using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToVideoSwitch : MonoBehaviour
{
    [SerializeField] private GameObject menuSceneStuff;

    [SerializeField] private GameObject QuestionCanvas;
    [SerializeField] private GameObject GamificationCanvas;
    [SerializeField] private GameObject questionDisplayBoard;
    [SerializeField] private GameObject questionAnswerBoard;
    [SerializeField] private GameObject wrongAnswerFeedback;
    [SerializeField] private GameObject correctAnswerFeedback;

    [SerializeField] private GameObject winScreen;

    [SerializeField] private ScoreManager score;
    private void Start()
    {
        menuSceneStuff.SetActive(true);
        questionDisplayBoard.SetActive(true);

        QuestionCanvas.SetActive(false);
        GamificationCanvas.SetActive(false);

        questionAnswerBoard.SetActive(false);
        wrongAnswerFeedback.SetActive(false);
        correctAnswerFeedback.SetActive(false);
        winScreen.SetActive(false);
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

        score.PausedVideo(false);
        QuestionCanvas.SetActive(false);
        GamificationCanvas.SetActive(false);
    }
}