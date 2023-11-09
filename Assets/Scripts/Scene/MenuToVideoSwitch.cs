using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToVideoSwitch : MonoBehaviour
{
    [SerializeField] private GameObject MenuSceneStuff;

    [SerializeField] private GameObject VideoSceneStuff;
    public void Switch()
    {
        VideoSceneStuff.SetActive(true);
        MenuSceneStuff.SetActive(false);
    }
}