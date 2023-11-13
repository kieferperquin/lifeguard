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

        debug.text = "set next question";
        SetNextQuestion();
        debug.text = "finished setting question and currentData = " + currentData;
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

        debug.text = "set question";

        SetQuestion(currentQuestionData);

        debug.text = "question have been set now setting answers";

        SetAnswers(currentQuestionData);

        currentData++;

        debug.text = "questions have been set and currentData = " + currentData;
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

        debug.text = "made array's";

        for (int i = 0; i < currentQuestionData.correctAnswers.Length; i++)
        {
            correctAnswerArray[i] = currentQuestionData.correctAnswers[i];
        }

        debug.text = "put every correct answer in the correctAnswerArray";

        for (int i = 0; i < currentQuestionData.wrongAnswers.Length; i++)
        {
            wrongAnswerArray[i] = currentQuestionData.wrongAnswers[i];
        }

        debug.text = "put every wrong answer in the wrongAnswerArray";

        if (currentQuestionData.allCorrect)// true
        {
            debug.text = "only correct answers";

            AllCorrectAsnwers(correctAnswerArray);
        }
        else
        {
            debug.text = "one correct answer";

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

        debug.text = "made list and the random number = " + correctAnswer;

        for (int i = 0; i < wrongAnswerArray.Length; i++)
        {
            arrayAmount.Add(i);
        }

        if (correctAnswer == 1)
        {
            SetCorrectAnswer(answerText1, answerObject1, correctAnswerArray);

            debug.text = "set correct answer for 1";

            SetWrongAnswer(answerText2, answerObject2, wrongAnswerArray);

            debug.text = "set wrong answer1 for 1";

            SetWrongAnswer(answerText3, answerObject3, wrongAnswerArray);

            debug.text = "set wrong answerw for 1";

            SetWrongAnswer(answerText4, answerObject4, wrongAnswerArray);

            debug.text = "set wrong answer3 for 1";

        }
        else if (correctAnswer == 2)
        {
            SetCorrectAnswer(answerText2, answerObject2, correctAnswerArray);

            debug.text = "set correct answer for 2";

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerArray);

            debug.text = "set wrong answer1 for 2";

            SetWrongAnswer(answerText3, answerObject3, wrongAnswerArray);

            debug.text = "set wrong answer2 for 2";

            SetWrongAnswer(answerText4, answerObject4, wrongAnswerArray);

            debug.text = "set wrong answer3 for 2";

        }
        else if (correctAnswer == 3)
        {
            SetCorrectAnswer(answerText3, answerObject3, correctAnswerArray);

            debug.text = "set correct answer for 3";

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerArray);

            debug.text = "set wrong answer1 for 3";

            SetWrongAnswer(answerText2, answerObject2, wrongAnswerArray);

            debug.text = "set wrong answer2 for 3";

            SetWrongAnswer(answerText4, answerObject4, wrongAnswerArray);

            debug.text = "set wrong answer3 for 3";

        }
        else if (correctAnswer == 4)
        {
            SetCorrectAnswer(answerText4, answerObject4, correctAnswerArray);

            debug.text = "set correct answer for 4";

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerArray);

            debug.text = "set wrong answer1 for 4";

            SetWrongAnswer(answerText2, answerObject2, wrongAnswerArray);

            debug.text = "set wrong answer2 for 4";

            SetWrongAnswer(answerText3, answerObject3, wrongAnswerArray);

            debug.text = "set wrong answer3 for 4";

        }
    }

    void SetCorrectAnswer(Text answerText, GameObject answerObject, string[] correctAnswerArray)
    {
        debug.text = "start set correct answer";

        int randomCorrectAnswer = Random.Range(1, arrayAmount.Count);
        answerText.text = correctAnswerArray[randomCorrectAnswer];

        debug.text = "set tag correct answer";

        answerObject.tag = "correct";

        debug.text = "end before removeAt set correct answer and after tag set";

        arrayAmount.RemoveAt(randomCorrectAnswer);

        debug.text = "end set correct answer";
    }

    void SetWrongAnswer(Text answerText, GameObject answerObject, string[] wrongAnswerArray)
    {
        debug.text = "start set wrong answer";

        int randomWrongAnswer = Random.Range(1, arrayAmount.Count);
        answerText.text = wrongAnswerArray[arrayAmount[randomWrongAnswer]];

        debug.text = "set tag wrong answer";

        answerObject.tag = "wrong";

        debug.text = "end before removeAt set wrong answer and after tag set";

        arrayAmount.RemoveAt(randomWrongAnswer);

        debug.text = "end set wrong answer";
    }
}