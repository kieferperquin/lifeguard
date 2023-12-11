using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    public void SetBarSize(int maxScore, int currentScore)
    {
        gameObject.GetComponent<Image>().fillAmount = currentScore / maxScore;
    }
}