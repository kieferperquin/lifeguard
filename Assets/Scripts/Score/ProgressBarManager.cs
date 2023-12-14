using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    [SerializeField] private Text text;
    public void SetBarSize(int currentAmount, int maxAmount)
    {
        gameObject.GetComponent<Image>().fillAmount = (currentAmount * 1.0f) / (maxAmount * 1.0f);
        text.text = $"{currentAmount}/{maxAmount}";
    }
}