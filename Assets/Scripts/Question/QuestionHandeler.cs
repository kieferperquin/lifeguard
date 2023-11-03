using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionHandeler : MonoBehaviour
{
    #region tiggers/needs for input
    public TriggersListObject.Triggers answerButtonLeft;
    private string leftButton;
    
    public TriggersListObject.Triggers answerButtonRight;
    private string rightButton;

    private float sens = .5f;
    #endregion

    #region question variables
    [SerializeField] private QuestionsSO[] questionsDataArray;

    private int currentData = 0;

    [SerializeField] private Text questionDisplayText, questionText;
    [SerializeField] private GameObject answerObject1, answerObject2, answerObject3, answerObject4;
    private Text answerText1, answerText2, answerText3, answerText4;

    [SerializeField] private GameObject questionAnswerBoard;
    [SerializeField] private GameObject questionDisplayBoard;

    private bool displayActivated = false;
    private bool isActivadedOnce = false;
    #endregion

    [SerializeField] private Text debug;
    void Start()
    {
        leftButton = answerButtonLeft.ToString();
        rightButton = answerButtonRight.ToString();

        answerText1 = answerObject1.GetComponent<Text>();
        answerText2 = answerObject2.GetComponent<Text>();
        answerText3 = answerObject3.GetComponent<Text>();
        answerText4 = answerObject4.GetComponent<Text>();

        SetQuestion();
    }

    void Update()
    {
        CheckButtonPress();

        SetDisplayActive();
    }

    void CheckButtonPress()
    {
        bool triggerLeft = Input.GetAxis(leftButton) >= sens;
        bool triggerRight = Input.GetAxis(rightButton) >= sens;

        if ((triggerLeft || triggerRight) && isActivadedOnce)
        {
            isActivadedOnce = true;
            displayActivated = !displayActivated;
        }
        else
        {
            isActivadedOnce = false;
        }
    }

    void SetDisplayActive()
    {
        if (displayActivated)//true
        {
            questionAnswerBoard.SetActive(true);
            questionDisplayBoard.SetActive(false);
        }
        else
        {
            questionAnswerBoard.SetActive(false);
            questionDisplayBoard.SetActive(true);
        }
    }

    public void SetQuestion()
    {
        QuestionsSO currentQuestionData = questionsDataArray[currentData];

        questionDisplayText.text = currentQuestionData.question;
        questionText.text = currentQuestionData.question;

        string[] answersArray = { currentQuestionData.correctAnswer };

        int foreachInt = 0;
        foreach (var item in currentQuestionData.wrongAnswers)
        {
            foreachInt++;
            answersArray[foreachInt] = currentQuestionData.wrongAnswers[foreachInt - 1];
        }

        debug.text = string.Join("", answersArray);


        //need to put a randomizer here
        answerText1.text = answersArray[1];
        answerObject1.tag = "correct";
        answerText2.text = answersArray[2];
        answerObject1.tag = "wrong";
        answerText3.text = answersArray[3];
        answerObject1.tag = "wrong";
        answerText4.text = answersArray[4];
        answerObject1.tag = "wrong";

        displayActivated = false;
        currentData++;
    }
}