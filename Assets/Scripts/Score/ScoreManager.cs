using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private float timeInMenu = 0;

    private bool isInMenu = false;

    [SerializeField] private Text debug;
    void Update()
    {
        if (isInMenu)
        {
            timeInMenu += Time.deltaTime;
        }

        //debug.text = timeInMenu.ToString();
    }

    public void ChangeIsInMenuBool(bool newBool)
    {
        isInMenu = newBool;
    }
}
