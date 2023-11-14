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

    private int currentData;
    private int maxDataAmount;

    [SerializeField] private Text questionDisplayText, questionText;
    [SerializeField] private GameObject answerObject1, answerObject2, answerObject3, answerObject4;
    private Text answerText1, answerText2, answerText3, answerText4;

    [SerializeField] private GameObject questionAnswerBoard;
    [SerializeField] private GameObject questionDisplayBoard;

    private bool displayActivated = false;
    private bool isActivadedOnce = true;
    #endregion

    private List<int> correctListAmount;
    private List<int> wrongListAmount;

    [SerializeField] private Text debug;
    void Start()
    {
        currentData = 0;
        maxDataAmount = questionsDataArray.Length;

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

        if (currentData >= maxDataAmount)
        {
            currentData++;
        }

        debug.text = "questions have been set and currentData = " + currentData;
    }
    
    void SetQuestion(QuestionsSO currentQuestionData)
    {
        questionDisplayText.text = currentQuestionData.question;
        questionText.text = currentQuestionData.question;
    }

    void SetAnswers(QuestionsSO currentQuestionData)
    {
        if (currentQuestionData.allCorrect)// true
        {
            debug.text = "only correct answers";

            AllCorrectAsnwers(currentQuestionData.correctAnswerList);
        }
        else
        {
            debug.text = "one correct answer";

            OneCorrectAnswer(currentQuestionData.wrongAnswerList, currentQuestionData.correctAnswerList);
        }
    }
    void AllCorrectAsnwers(List<string> correctAnswerList)
    {
        correctListAmount = new List<int> { };

        for (int i = 0; i < correctAnswerList.Count; i++)
        {
            correctListAmount.Add(i);
        }

        SetCorrectAnswer(answerText1, answerObject1, correctAnswerList);
        SetCorrectAnswer(answerText2, answerObject2, correctAnswerList);
        SetCorrectAnswer(answerText3, answerObject3, correctAnswerList);
        SetCorrectAnswer(answerText4, answerObject4, correctAnswerList);
    }

    void OneCorrectAnswer(List<string> wrongAnswerList, List<string> correctAnswerList)
    {
        int correctAnswer = Random.Range(1, 4);

        correctListAmount = new List<int>();
        wrongListAmount = new List<int>();

        debug.text = "made list and the random number = " + correctAnswer;

        for (int i = 0; i < correctAnswerList.Count; i++)
        {
            correctListAmount.Add(i);
        }

        for (int i = 0; i < wrongAnswerList.Count; i++)
        {
            wrongListAmount.Add(i);
        }

        if (correctAnswer == 1)
        {
            SetCorrectAnswer(answerText1, answerObject1, correctAnswerList);

            debug.text = "set correct answer for 1";

            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);

            debug.text = "set wrong answer1 for 1";

            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);

            debug.text = "set wrong answerw for 1";

            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);

            debug.text = "set wrong answer3 for 1";

        }
        else if (correctAnswer == 2)
        {
            SetCorrectAnswer(answerText2, answerObject2, correctAnswerList);

            debug.text = "set correct answer for 2";

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);

            debug.text = "set wrong answer1 for 2";

            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);

            debug.text = "set wrong answer2 for 2";

            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);

            debug.text = "set wrong answer3 for 2";

        }
        else if (correctAnswer == 3)
        {
            SetCorrectAnswer(answerText3, answerObject3, correctAnswerList);

            debug.text = "set correct answer for 3";

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);

            debug.text = "set wrong answer1 for 3";

            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);

            debug.text = "set wrong answer2 for 3";

            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);

            debug.text = "set wrong answer3 for 3";

        }
        else if (correctAnswer == 4)
        {
            SetCorrectAnswer(answerText4, answerObject4, correctAnswerList);

            debug.text = "set correct answer for 4";

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);

            debug.text = "set wrong answer1 for 4";

            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);

            debug.text = "set wrong answer2 for 4";

            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);

            debug.text = "set wrong answer3 for 4";

        }
    }

    void SetCorrectAnswer(Text answerText, GameObject answerObject, List<string> correctAnswerList)
    {
        int randomCorrectAnswer = Random.Range(1, correctListAmount.Count);

        debug.text = "start set correct answer random is = " + randomCorrectAnswer;

        answerText.text = correctAnswerList[correctListAmount[randomCorrectAnswer]];

        debug.text = "set tag correct answer";

        answerObject.tag = "correct";

        debug.text = "end before removeAt set correct answer and after tag set";

        correctListAmount.RemoveAt(randomCorrectAnswer);

        debug.text = "end set correct answer";
    }

    void SetWrongAnswer(Text answerText, GameObject answerObject, List<string> wrongAnswerList)
    {
        debug.text = "start set wrong answer";

        int randomWrongAnswer = Random.Range(1, wrongListAmount.Count);
        answerText.text = wrongAnswerList[wrongListAmount[randomWrongAnswer]];

        debug.text = "set tag wrong answer";

        answerObject.tag = "wrong";

        debug.text = "end before removeAt set wrong answer and after tag set";

        wrongListAmount.RemoveAt(randomWrongAnswer);

        debug.text = "end set wrong answer";
    }
}