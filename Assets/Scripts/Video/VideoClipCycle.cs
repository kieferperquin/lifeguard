using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoClipCycle : MonoBehaviour
{
    public List<QuestionsSO> questionsSOList = new List<QuestionsSO>();

    private VideoClip videoClip;
    
    private VideoPlayer Player;

    private int CurrClip = -1;
    private void Start()
    {
        Player = gameObject.GetComponent<VideoPlayer>();        
    }
    public void NextClip()
    {
        CurrClip++;

        videoClip = questionsSOList[CurrClip].videoClip;

        Player.clip = videoClip;
        Player.Play();
    }
}