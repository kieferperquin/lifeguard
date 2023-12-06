using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private float timeInMenu = 0;
    private float timeAnswering = 0;

    private bool isInMenu = false;
    private bool isAnswering = false;

    [SerializeField] private Text ScoreText;

    [SerializeField] private Text debug;
    void Update()
    {
        if (isAnswering)
        {
            timeAnswering = Time.deltaTime;
            if (timeAnswering >= 10)
            {
                isInMenu = true;
            }
        }

        if (isInMenu)
        {
            timeInMenu += Time.deltaTime;
        }

        ScoreText.text = "seconds spent in menu's = " + Mathf.Round(timeInMenu * 100f) / 100f;
        ;

        //debug.text = timeInMenu.ToString();
    }

    public void PausedVideo(bool newBool)
    {
        isInMenu = newBool;
    }

    public void ChangeIsAnswering(bool newBool)
    {
        isAnswering = newBool;
        timeAnswering = 0;
    }
}
