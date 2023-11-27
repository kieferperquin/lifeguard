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
    private int maxDataAmount;

    [SerializeField] private Text questionDisplayText, questionText;
    [SerializeField] private GameObject answerObject1, answerObject2, answerObject3, answerObject4;
    private Text answerText1, answerText2, answerText3, answerText4;

    [SerializeField] private GameObject questionAnswerBoard;
    [SerializeField] private GameObject questionDisplayBoard;

    private bool displayActivated = false;
    private bool isActivadedOnce = true;
    #endregion

    private List<int> correctListIndexes;
    private List<int> wrongListIndexes;

    [SerializeField] private Text debug;
    void Start()
    {
        maxDataAmount = questionsDataArray.Length;

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
        displayActivated = false;

        RemoveText();

        SetQuestion(questionsDataArray[currentData]);

        debug.text = "1";
        SetAnswers(questionsDataArray[currentData]);
        debug.text = "22";
        currentData++;
    }

    void RemoveText()
    {
        answerText1.text = "";
        answerText2.text = "";
        answerText3.text = "";
        answerText4.text = "";
    }


    void SetQuestion(QuestionsSO currentQuestionData)
    {
        questionDisplayText.text = currentQuestionData.question;
        questionText.text = currentQuestionData.question;
    }

    void SetAnswers(QuestionsSO currentQuestionData)
    {
        if (currentQuestionData.allCorrect || !currentQuestionData.pointClick)// true and false
        {
            AllCorrectAsnwers(currentQuestionData.correctAnswerList);
        }
        else if (!currentQuestionData.allCorrect || currentQuestionData.pointClick)//false and true
        {

        }
        else
        {
            OneCorrectAnswer(currentQuestionData.wrongAnswerList, currentQuestionData.correctAnswerList);
        }
    }
    void AllCorrectAsnwers(List<string> correctAnswerList)
    {
        correctListIndexes = new List<int> { };

        for (int i = 0; i < correctAnswerList.Count; i++)
        {
            correctListIndexes.Add(i);
        }

        SetCorrectAnswer(answerText1, answerObject1, correctAnswerList);
        SetCorrectAnswer(answerText2, answerObject2, correctAnswerList);
        SetCorrectAnswer(answerText3, answerObject3, correctAnswerList);
        SetCorrectAnswer(answerText4, answerObject4, correctAnswerList);
    }

    void OneCorrectAnswer(List<string> wrongAnswerList, List<string> correctAnswerList)
    {
        debug.text = "2";
        int correctAnswer = Random.Range(1, 4);
        debug.text = "3";
        correctListIndexes = new List<int>();
        wrongListIndexes = new List<int>();
        debug.text = "4";
        for (int i = 0; i < correctAnswerList.Count; i++)
        {
            correctListIndexes.Add(i);
        }
        debug.text = "5";
        for (int i = 0; i < wrongAnswerList.Count; i++)
        {
            wrongListIndexes.Add(i);
        }
        debug.text = "6";
        correctAnswer = 2;

        if (correctAnswer == 1)
        {
            RemoveText();
            SetCorrectAnswer(answerText1, answerObject1, correctAnswerList);

            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
        }
        else if (correctAnswer == 2)
        {
            RemoveText();
            debug.text = "7";
            SetCorrectAnswer(answerText2, answerObject2, correctAnswerList);

            debug.text = "8";
            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            debug.text = "9";
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
            debug.text = "10";
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
            debug.text = "11";
        }
        else if (correctAnswer == 3)
        {
            RemoveText();
            SetCorrectAnswer(answerText3, answerObject3, correctAnswerList);

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
        }
        else if (correctAnswer == 4)
        {
            RemoveText();
            SetCorrectAnswer(answerText4, answerObject4, correctAnswerList);

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
        }
    }

    void SetCorrectAnswer(Text answerText, GameObject answerObject, List<string> correctAnswerList)
    {
        debug.text = "12";
        int randomCorrectAnswer = Random.Range(0, correctListIndexes.Count);
        debug.text = "13";
        answerText.text = correctAnswerList[correctListIndexes[randomCorrectAnswer]];
        debug.text = "14";
        correctListIndexes.RemoveAt(randomCorrectAnswer);
        debug.text = "15";
        answerObject.tag = "Correct";
        debug.text = "16";
    }

    void SetWrongAnswer(Text answerText, GameObject answerObject, List<string> wrongAnswerList)
    {
        debug.text = "17";
        int randomWrongAnswer = Random.Range(0, wrongListIndexes.Count);
        debug.text = "18";
        answerText.text = wrongAnswerList[wrongListIndexes[randomWrongAnswer]];
        debug.text = "19";
        wrongListIndexes.RemoveAt(randomWrongAnswer);
        debug.text = "20";
        answerObject.tag = "Wrong";
        debug.text = "21";
    }
}