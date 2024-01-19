using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOnClick : MonoBehaviour
{
    [SerializeField] private GameObject question;

    private DestroyGameObject destroy;
    private AnswerCheck answerCheck;

    private Button button;
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        
        answerCheck = GameObject.Find("QuestionHandeler").GetComponent<AnswerCheck>();

        destroy = question.GetComponent<DestroyGameObject>();
    }

    public void OnClickEvent()
    {
        answerCheck.CheckAnswer(button.gameObject);
        destroy.GameObjectDestroyer(question);
    }
}