using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AnswerCheck : MonoBehaviour
{
    [SerializeField] private Text debug;
    [SerializeField] private VideoPlayer videoPlayer;
    public void CheckAnswer()
    {
        debug.text = gameObject.tag;
    }
}
