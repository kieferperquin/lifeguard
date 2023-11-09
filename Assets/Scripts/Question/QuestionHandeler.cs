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

    private List<int> arrayAmount;

    [SerializeField] private Text debug;
    void Start()
    {
        leftButton = answerButtonLeft.ToString();
        rightButton = answerButtonRight.ToString();
        
        answerText1 = answerObject1.GetComponentInChildren<Text>();
        answerText2 = answerObject2.GetComponentInChildren<Text>();
        answerText3 = answerObject3.GetComponentInChildren<Text>();
        answerText4 = answerObject4.GetComponentInChildren<Text>();

        SetNextQuestion();
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

    public void SetNextQuestion()
    {
        QuestionsSO currentQuestionData = questionsDataArray[currentData];

        displayActivated = false;

        SetQuestion(currentQuestionData);
        SetAnswers(currentQuestionData);

        currentData++;
    }
    
    void SetQuestion(QuestionsSO currentQuestionData)
    {
        questionDisplayText.text = currentQuestionData.question;
        questionText.text = currentQuestionData.question;
    }

    void SetAnswers(QuestionsSO currentQuestionData)
    {
        string[] correctAnswerArray = { };
        string[] wrongAnswerArray = { };

        for (int i = 0; i < currentQuestionData.correctAnswers.Length; i++)
        {
            correctAnswerArray[i] = currentQuestionData.correctAnswers[i];
        }

        for (int i = 0; i < currentQuestionData.wrongAnswers.Length; i++)
        {
            wrongAnswerArray[i] = currentQuestionData.wrongAnswers[i];
        }


        

        if (currentQuestionData.allCorrect)// true
        {
            AllCorrectAsnwers(correctAnswerArray);
        }
        else
        {
            OneCorrectAnswer(wrongAnswerArray, correctAnswerArray);
        }
    }
    void AllCorrectAsnwers(string[] correctAnswerArray)
    {
        arrayAmount = new List<int> { };

        for (int i = 0; i < correctAnswerArray.Length; i++)
        {
            arrayAmount.Add(i);
        }

        SetCorrectAnswer(answerText1, answerObject1, correctAnswerArray);
        SetCorrectAnswer(answerText2, answerObject2, correctAnswerArray);
        SetCorrectAnswer(answerText3, answerObject3, correctAnswerArray);
        SetCorrectAnswer(answerText4, answerObject4, correctAnswerArray);
    }

    void OneCorrectAnswer(string[] wrongAnswerArray, string[] correctAnswerArray)
    {
        int correctAnswer = Random.Range(1, 4);

        arrayAmount = new List<int> { };

        for (int i = 0; i < wrongAnswerArray.Length; i++)
        {
            arrayAmount.Add(i);
        }

        if (correctAnswer == 1)
        {
            SetCorrectAnswer(answerText1, answerObject1, correctAnswerArray);

            SetWrongAnswer(answerText2, answerObject2, wrongAnswerArray);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerArray);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerArray);
        }
        else if (correctAnswer == 2)
        {
            SetCorrectAnswer(answerText2, answerObject2, correctAnswerArray);

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerArray);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerArray);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerArray);
        }
        else if (correctAnswer == 3)
        {
            SetCorrectAnswer(answerText3, answerObject3, correctAnswerArray);

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerArray);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerArray);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerArray);
        }
        else if (correctAnswer == 4)
        {
            SetCorrectAnswer(answerText4, answerObject4, correctAnswerArray);

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerArray);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerArray);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerArray);
        }
    }

    void SetCorrectAnswer(Text answerText, GameObject answerObject, string[] correctAnswerArray)
    {
        int randomCorrectAnswer = Random.Range(1, arrayAmount.Count);
        answerText.text = correctAnswerArray[randomCorrectAnswer];
        answerObject.tag = "correct";
        arrayAmount.RemoveAt(randomCorrectAnswer);
    }

    void SetWrongAnswer(Text answerText, GameObject answerObject, string[] wrongAnswerArray)
    {
        int randomWrongAnswer = Random.Range(1, arrayAmount.Count);
        answerText.text = wrongAnswerArray[arrayAmount[randomWrongAnswer]];
        answerObject.tag = "wrong";
        arrayAmount.RemoveAt(randomWrongAnswer);
    }
}