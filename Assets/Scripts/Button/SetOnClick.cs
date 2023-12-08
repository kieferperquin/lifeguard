using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOnClick : MonoBehaviour
{
    [SerializeField] private GameObject question;

    private DestroyGameObject function;
    private AnswerCheck check;

    private Button button;
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        
        check = GameObject.Find("QuestionHandeler").GetComponent<AnswerCheck>();
        function = question.GetComponent<DestroyGameObject>();
    }

    public void OnClickEvent()
    {
        check.CheckAnswer(button.gameObject);
        function.GameObjectDestroyer(question);
    }
}