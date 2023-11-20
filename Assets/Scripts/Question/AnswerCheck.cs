using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AnswerCheck : MonoBehaviour
{
    [SerializeField] private Text debug;
    [SerializeField] private VideoPlayer videoPlayer;

    private VideoClipCycle function;

    public void CheckAnswer(GameObject button)
    {
        debug.text = button.tag;
        if (button.CompareTag("Correct"))
        {
            function.NextClip();
        }
        else if (button.CompareTag("Wrong"))
        {

        }
    }
}