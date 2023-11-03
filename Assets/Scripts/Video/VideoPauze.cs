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

    private bool isPaused;

    string buttonTrigger;

    private void Start()
    {
        buttonTrigger = buttonLeft.ToString();
        buttonTrigger = buttonRight.ToString();
    }
    private void Update()
    {
        buttonPressed();

        if (isPaused)//true
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }

    void buttonPressed()
    {
        bool trigger = Input.GetButton(buttonTrigger);
        if (!trigger)//false
        {
            trigger = Input.GetButton(buttonTrigger);
            if (!trigger)//false
            {
                isPaused = false;
            }
            else
            {
                isPaused = true;
            }
        }
        else
        {
            isPaused = true;
        }
    }
}