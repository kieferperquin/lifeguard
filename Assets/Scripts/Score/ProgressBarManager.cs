using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    [SerializeField] private Image fillObject;
    public void SetBarSize(float fillVolume)
    {
        fillObject.fillAmount = fillVolume;
    }
}