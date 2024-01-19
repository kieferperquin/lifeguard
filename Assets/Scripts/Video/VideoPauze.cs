using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPauze : MonoBehaviour
{
    public TriggersListObject.Triggers buttonLeft;
    public TriggersListObject.Triggers buttonRight;

    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private ScoreManager functionScoreManager;
    [SerializeField] private QuestionMenuHandeler functionQuestionMenuHandeler;

    private bool isPaused;
    private bool isActivatedOnce;

    private string buttonTriggerL;
    private string buttonTriggerR;

    [SerializeField] private Text debug;

    private void Start()
    {
        buttonTriggerL = buttonLeft.ToString();
        buttonTriggerR = buttonRight.ToString();
    }

    private void Update()
    {
        ButtonPressed();

        if (videoPlayer.time !>= videoPlayer.length - .5)
        {
            functionQuestionMenuHandeler.SetDisplayVar(true);
            functionScoreManager.ChangeIsAnswering(true);
        }
    }

    void ButtonPressed()
    {
        bool triggerL = Input.GetButton(buttonTriggerL);
        bool triggerR = Input.GetButton(buttonTriggerR);

        if ((triggerL || triggerR) && isActivatedOnce)//true and true
        {
            isActivatedOnce = false;
            isPaused = !isPaused;
            ChangePaused();
        }
        else if ((triggerL || triggerR) && !isActivatedOnce)// true and false
        {
            // do nothing just make sure it only fires once
        }
        else
        {
            isActivatedOnce = true;
        }
    }

    public void ChangePausedBool(bool newPausedState)
    {
        isPaused = newPausedState;
        ChangePaused();
    }

    void ChangePaused()
    {
        if (isPaused)//true
        {
            videoPlayer.Pause();

            functionScoreManager.PausedVideo(true); //score now gets added
        }
        else
        {
            if (videoPlayer.time <= videoPlayer.length - 1)
            {
                videoPlayer.Play();
                functionScoreManager.PausedVideo(false); //score now stops getting added
            }
        }
    }
}