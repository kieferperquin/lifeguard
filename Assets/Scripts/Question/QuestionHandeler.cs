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

    private List<int> correctListAmount;
    private List<int> wrongListAmount;

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

        SetAnswers(questionsDataArray[currentData]);

        currentData++;

        if (currentData == 1)
        {
            debug.text = "currentData = " + currentData;
        }
        else
        {
            debug.text = "currentData = " + currentData + " oegaboega";
        }
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
        if (currentQuestionData.allCorrect)// true
        {
            AllCorrectAsnwers(currentQuestionData.correctAnswerList);
        }
        else
        {
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

        debug.text = "made random going to make lists";

        correctListAmount = new List<int>();
        wrongListAmount = new List<int>();

        debug.text = "made lists now adding shit to the lists";

        for (int i = 0; i < correctAnswerList.Count; i++)
        {
            correctListAmount.Add(i);
        }

        for (int i = 0; i < wrongAnswerList.Count; i++)
        {
            wrongListAmount.Add(i);
        }

        correctAnswer = 1;
        debug.text = "added shit to the lists now selecting the random and setting the answers";


        if (correctAnswer == 1)
        {

            SetCorrectAnswer(answerText1, answerObject1, correctAnswerList);
            debug.text = "correct answer has been set";

            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            debug.text = "wrong answer 1 has been set";
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
            debug.text = "wrong answer 2 has been set";
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
            debug.text = "wrong answer 3 has been set";
        }
        else if (correctAnswer == 2)
        {
            SetCorrectAnswer(answerText2, answerObject2, correctAnswerList);

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
        }
        else if (correctAnswer == 3)
        {
            SetCorrectAnswer(answerText3, answerObject3, correctAnswerList);

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
        }
        else if (correctAnswer == 4)
        {
            SetCorrectAnswer(answerText4, answerObject4, correctAnswerList);

            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
        }
    }

    void SetCorrectAnswer(Text answerText, GameObject answerObject, List<string> correctAnswerList)
    {
        int randomCorrectAnswer = Random.Range(1, correctListAmount.Count);

        debug.text = "made random a random int and its " + randomCorrectAnswer + "correctListAmount.Count = " + correctAnswerList.Count;

        answerText.text = correctAnswerList[correctListAmount[randomCorrectAnswer]];
        debug.text = "set the answer";

        answerObject.tag = "correct";
        debug.text = "set tag";

        correctListAmount.RemoveAt(randomCorrectAnswer);
        debug.text = "removed from list";
    }

    void SetWrongAnswer(Text answerText, GameObject answerObject, List<string> wrongAnswerList)
    {
        int randomWrongAnswer = Random.Range(1, wrongListAmount.Count);
        answerText.text = wrongAnswerList[wrongListAmount[randomWrongAnswer]];
        answerObject.tag = "wrong";
        wrongListAmount.RemoveAt(randomWrongAnswer);
    }
}