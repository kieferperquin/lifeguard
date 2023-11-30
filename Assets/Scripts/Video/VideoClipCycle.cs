using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoClipCycle : MonoBehaviour
{
    [SerializeField] private VideoPlayer Player;
    public void SetClip(QuestionsSO currentData)
    {
        Player.clip = currentData.videoClip;
    }

    public void PlayClip()
    {
        Player.Play();
    }
}