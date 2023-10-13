using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPauze : MonoBehaviour
{
    public TriggersListObject.Triggers buttonLeft;
    public TriggersListObject.Triggers buttonRight;

    [SerializeField] private GameObject videoPlayerObject;

    private VideoPlayer videoPlayer;

    private bool isPauzedLeft = false;
    private bool isPauzedRight = false;

    string buttonTrigger;

    private void Start()
    {
        videoPlayer = videoPlayerObject.GetComponent<VideoPlayer>();
    }
    private void Update()
    {
        buttonTrigger = buttonLeft.ToString();
        isPauzedLeft = Input.GetButton(buttonTrigger);

        buttonTrigger = buttonRight.ToString();
        isPauzedRight = Input.GetButton(buttonTrigger);

        if (isPauzedLeft || isPauzedRight) //both are true
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }
}