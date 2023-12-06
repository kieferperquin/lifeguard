using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToVideoSwitch : MonoBehaviour
{
    [SerializeField] private GameObject menuSceneStuff;

    [SerializeField] private GameObject videoSceneStuff;
    [SerializeField] private GameObject questionDisplayBoard;
    [SerializeField] private GameObject questionAnswerBoard;

    [SerializeField] private GameObject winScreen;

    [SerializeField] private ScoreManager score;
    private void Start()
    {
        videoSceneStuff.SetActive(false);
        menuSceneStuff.SetActive(true);
        questionDisplayBoard.SetActive(true);
        questionAnswerBoard.SetActive(false);
        winScreen.SetActive(false);
    }
    public void Switch()
    {
        videoSceneStuff.SetActive(true);
        menuSceneStuff.SetActive(false);
    }

    public void Win()
    {
        score.PausedVideo(false);
        winScreen.SetActive(true);
        videoSceneStuff.SetActive(false);
    }
}