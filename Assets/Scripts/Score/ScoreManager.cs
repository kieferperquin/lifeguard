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

        totalTimeText.text = Mathf.RoundToInt(totalTime).ToString() + " seconds";

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
        int timeInMenuInSec = Mathf.RoundToInt(timeInMenu * 100f);
        int timeInMenuInMin = Mathf.RoundToInt(timeInMenuInSec * 60);
        int totalTimeInSec = Mathf.RoundToInt(totalTime * 100f);

        ScoreText.text = 
            $"Secondes in menu's = {timeInMenuInSec}" +
            $"Dat is {timeInMenuInMin} minuten en {timeInMenuInSec - (timeInMenuInMin * 60)} seconden" +
            $"Intotaal is dat {totalTimeInSec}";
    }

    public void SetTotalTimerToZero()
    {
        totalTime = 0f;
    }
}
