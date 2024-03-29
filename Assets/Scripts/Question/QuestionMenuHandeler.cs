using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMenuHandeler : MonoBehaviour
{
    public TriggersListObject.Triggers answerButtonLeft;
    private string leftButton;

    public TriggersListObject.Triggers answerButtonRight;
    private string rightButton;

    private bool displayActivated = false;
    private bool isActivadedOnce = true;

    [SerializeField] private GameObject questionAnswerBoard;
    [SerializeField] private GameObject questionDisplayBoard;

    [SerializeField] private GameObject pointClickQuestion;

    [SerializeField] private VideoPauze function;
    void Start()
    {
        // set the trigger to string
        leftButton = answerButtonLeft.ToString();
        rightButton = answerButtonRight.ToString();
    }

    void Update()
    {
        CheckButtonPress();
    }

    void CheckButtonPress()
    {
        // checks if one button is pressed
        bool triggerLeft = Input.GetButton(leftButton);
        bool triggerRight = Input.GetButton(rightButton);

        if ((triggerLeft || triggerRight) && isActivadedOnce)// if one of the buttons is pressed activate
        {
            isActivadedOnce = false;
            displayActivated = !displayActivated;

            SetDisplayActive();
        }
        else if ((triggerLeft || triggerRight) && !isActivadedOnce)
        {
            //do nothing but to make it so it does not give you epelepsy
        }
        else
        {
            isActivadedOnce = true; // when buttons released reset variable so the menu can close / open again
        }
    }

    void SetDisplayActive()
    {
        // opens the menu so the player can answer the questions
        if (displayActivated)//true
        {
            if (pointClickQuestion != null)
            {
                //set a question menu for the point click questions true
                questionAnswerBoard.SetActive(true); //need to remove this one
                pointClickQuestion.SetActive(true);
            }
            else
            {
                questionAnswerBoard.SetActive(true);
            }

            questionDisplayBoard.SetActive(false);

            function.ChangePausedBool(true);
        }
        else
        {
            if (pointClickQuestion != null)
            {
                //set a question menu for the point click questions false
                questionAnswerBoard.SetActive(false); //need to remove this one
                pointClickQuestion.SetActive(false);
            }
            else
            {
                questionAnswerBoard.SetActive(false);
            }

            questionDisplayBoard.SetActive(true);

            function.ChangePausedBool(false);
        }
    }

    public void SetDisplayVar(bool newDisplayActive)
    {
        displayActivated = newDisplayActive;
        SetDisplayActive();
    }

    public void SetPointClickQuestionGameObject(GameObject pointClickObject)
    {
        pointClickQuestion = pointClickObject;
    }
}