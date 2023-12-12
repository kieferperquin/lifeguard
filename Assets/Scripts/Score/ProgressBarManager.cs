using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    [SerializeField] private Image fillObject;
    public void SetBarSize(int maxScore, int currentScore)
    {        
        fillObject.fillAmount = currentScore / maxScore;
    }
}