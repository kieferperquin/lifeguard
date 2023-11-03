using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionHandeler : MonoBehaviour
{
    #region triggers/needs for input
    public TriggersListObject.Triggers answerButtonLeft;
    private string leftButton;
    
    public TriggersListObject.Triggers answerButtonRight;
    private string rightButton;
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
    private bool isActivadedOnce = true;
    #endregion

    [SerializeField] private Text debug;
    void Start()
    {
        leftButton = answerButtonLeft.ToString();
        rightButton = answerButtonRight.ToString();
        
        answerText1 = answerObject1.GetComponentInChildren<Text>();
        answerText2 = answerObject2.GetComponentInChildren<Text>();
        answerText3 = answerObject3.GetComponentInChildren<Text>();
        answerText4 = answerObject4.GetComponentInChildren<Text>();

        SetQuestion();
    }

    void Update()
    {
        CheckButtonPress();

        SetDisplayActive();
    }

    void CheckButtonPress()
    {
        bool triggerLeft = Input.GetButton(leftButton);
        bool triggerRight = Input.GetButton(rightButton);

        if ((triggerLeft || triggerRight) && isActivadedOnce)
        {
            isActivadedOnce = false;
            displayActivated = !displayActivated;
        }
        else if((triggerLeft || triggerRight) && !isActivadedOnce)
        {
            //do nothing but to make it so it does not give you epelepsy
        }
        else
        {
            isActivadedOnce = true;
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

        debug.text = "hello";
        debug.text = string.Join("", answersArray);



        SetAnswers(answersArray);

        displayActivated = false;
        currentData++;
    }

    void SetAnswers(string[] answersArray)
    {
        int correctAnswer = Random.Range(1, 4);
        int[] wrongAnswers = {2, 3, 4};
        int randomWrongAnswer;

        if (correctAnswer == 1)
        {
            answerText1.text = answersArray[1];
            answerObject1.tag = "correct";
            
            randomWrongAnswer = Random.Range(0, wrongAnswers.Length);
            answerText2.text = answersArray[wrongAnswers[randomWrongAnswer]];
            answerObject2.tag = "wrong";
            
        }


        /*else
        {
            wrongAnswer = Random.Range(2, 4);
            answerText1.text = answersArray[wrongAnswer];
            answerObject1.tag = "wrong";
        }*/
    }
}