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
        int timeInSec = Mathf.RoundToInt(timeInMenu * 100f);
        int timeInMin = Mathf.RoundToInt(timeInSec * 60);

        ScoreText.text = $"secondes in menu's = {timeInSec}           dat is {timeInMin} minuten en {timeInSec - (timeInMin * 60)} seconden";
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
