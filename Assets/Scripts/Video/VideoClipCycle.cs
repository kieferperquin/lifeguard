using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoClipCycle : MonoBehaviour
{
    [SerializeField] private VideoPlayer Player;
    public void NextClip(QuestionsSO currentData)
    {
        Player.clip = currentData.videoClip;
        Player.Play();
    }
}