using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class VideoClipCycle : MonoBehaviour
{
    [SerializeField] private VideoClip[] clips;
    private VideoPlayer Player;

    private int CurrClip = -1;
    private int MaxClip;
    private void Start()
    {
        Player = gameObject.GetComponent<VideoPlayer>();

        if (clips.Length <= 0)
        { 
            clips = Resources.LoadAll("VideoClips", typeof(VideoClip)).Cast<VideoClip>().ToArray();
        }
    }
    public void NextClip()
    {
        MaxClip = clips.Length;

        CurrClip++;

        if (CurrClip <= MaxClip)
        {
            Player.clip = clips[CurrClip];
            Player.Play();
        }
    }
}