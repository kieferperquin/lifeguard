using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private float timeInMenu = 0;
    private float timeAnswering = 0;
    private float totalTime = 0;

    private bool isInMenu = false;
    private bool isAnswering = false;

    [SerializeField] private Text ScoreText;
    [SerializeField] private Text totalTimeText;

    [SerializeField] private Text debug;
    void Update()
    {
        totalTime += Time.deltaTime;

        //veranderen is digitaale clock als in 00:00 (min sec)
        int totalTimeInSeconds = Mathf.RoundToInt(totalTime);
        int totalTimeInMinutes = Mathf.RoundToInt(totalTimeInSeconds / 60);
        if (totalTimeInMinutes <= 9)
        {
            totalTimeText.text = $"0{totalTimeInMinutes}:{totalTimeInSeconds - (totalTimeInMinutes * 60)}";
        }
        else
        {
            totalTimeText.text = $"{totalTimeInMinutes}:{totalTimeInSeconds - (totalTimeInMinutes * 60)}";
        }

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

    public void SetEndingText()
    {
        int timeInMenuInSec = Mathf.RoundToInt(timeInMenu);
        int timeInMenuInMin = Mathf.RoundToInt(timeInMenuInSec / 60);
        int totalTimeInSec = Mathf.RoundToInt(totalTime);
        int totalTimeInMin = Mathf.RoundToInt(totalTimeInSec / 60);

        ScoreText.text = 
            $"Secondes in menu's = {timeInMenuInSec} " + "\n" +
            $"Dat is {timeInMenuInMin} minuten en {timeInMenuInSec - (timeInMenuInMin * 60)} seconden" + "\n" +
            $"Intotaal is dat {totalTimeInSec} seconden" + "\n" +
            $"Dat is intotaal {totalTimeInMin} minuten en {totalTimeInSec - (totalTimeInMin * 60)} seconden";
    }

    public void SetTotalTimerToZero()
    {
        totalTime = 0f;
    }
}
