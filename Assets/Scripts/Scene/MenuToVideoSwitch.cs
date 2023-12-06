using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToVideoSwitch : MonoBehaviour
{
    [SerializeField] private GameObject MenuSceneStuff;

    [SerializeField] private GameObject VideoSceneStuff;
    [SerializeField] private GameObject QuestionDisplayBoard;
    [SerializeField] private GameObject QuestionAnswerBoard;

    private void Start()
    {
        VideoSceneStuff.SetActive(false);
        MenuSceneStuff.SetActive(true);
        QuestionDisplayBoard.SetActive(true);
        QuestionAnswerBoard.SetActive(false);
    }
    public void Switch()
    {
        VideoSceneStuff.SetActive(true);
        MenuSceneStuff.SetActive(false);
    }
}