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

    private List<int> wrongAnswers;

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

        string[] wrongAnswerArray = { };

        for (int i = 0; i < currentQuestionData.wrongAnswers.Length; i++)
        {
            wrongAnswerArray[i] = currentQuestionData.wrongAnswers[i];
        }

        SetAnswers(currentQuestionData, wrongAnswerArray);

        displayActivated = false;
        currentData++;
    }

    void SetAnswers(QuestionsSO currentQuestionData, string[] wrongAnswerArray)
    {
        int correctAnswer = Random.Range(1, 4);
        wrongAnswers = new List<int> {2, 3, 4};

        if (correctAnswer == 1)
        {
            answerText1.text = currentQuestionData.correctAnswer;
            answerObject1.tag = "correct";

            SetWrongAnswer(answerText2, answerObject2, wrongAnswerArray);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerArray);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerArray);
        }
        else if (correctAnswer == 2)
        {
            answerText2.text = currentQuestionData.correctAnswer;
            answerObject2.tag = "correct";

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerArray);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerArray);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerArray);
        }
        else if (correctAnswer == 3)
        {
            answerText3.text = currentQuestionData.correctAnswer;
            answerObject3.tag = "correct";

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerArray);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerArray);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerArray);
        }
        else if (correctAnswer == 4)
        {
            answerText4.text = currentQuestionData.correctAnswer;
            answerObject4.tag = "correct";

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerArray);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerArray);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerArray);
        }
    }

    void SetWrongAnswer(Text answerText, GameObject answerObject, string[] wrongAnswerArray)
    {
        int randomWrongAnswer = Random.Range(0, wrongAnswers.Count);
        answerText.text = wrongAnswerArray[wrongAnswers[randomWrongAnswer]];
        answerObject.tag = "wrong";
        wrongAnswers.RemoveAt(randomWrongAnswer);
    }
}