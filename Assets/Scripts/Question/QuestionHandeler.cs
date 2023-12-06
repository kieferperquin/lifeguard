using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class QuestionHandeler : MonoBehaviour
{
    [SerializeField] private QuestionsSO[] questionsDataArray;

    private int currentData = 0;

    [SerializeField] private Text questionDisplayText, questionText;
    [SerializeField] private GameObject answerObject1, answerObject2, answerObject3, answerObject4;
    private Text answerText1, answerText2, answerText3, answerText4;

    private List<int> correctListAmount;
    private List<int> wrongListAmount;

    [SerializeField] private QuestionMenuHandeler functionQuestionMenuHandeler;
    [SerializeField] private VideoClipCycle functionVideoClipCycle;
    [SerializeField] private VideoPauze functionVideoPauze;

    [SerializeField] private Text debug;
    void Start()
    {        
        // get text objects from buttons
        answerText1 = answerObject1.GetComponentInChildren<Text>();
        answerText2 = answerObject2.GetComponentInChildren<Text>();
        answerText3 = answerObject3.GetComponentInChildren<Text>();
        answerText4 = answerObject4.GetComponentInChildren<Text>();

        // run once so in the start you have a question
        SetNextQuestion();
    }
    public void SetNextQuestion()
    {
        functionVideoClipCycle.SetClip(questionsDataArray[currentData]);

        functionQuestionMenuHandeler.SetDisplayVar(false); // set display activated to false so when you answer the menu does not stay open

        RemoveTextAndTags(); // removes the text before setting it again (just to make sure it works)

        SetQuestion(questionsDataArray[currentData]); // sets the question text

        SetAnswers(questionsDataArray[currentData]); // sets the answers

        currentData++;
    }

    void RemoveTextAndTags()
    {/*
        //set the tag to untagged 
        answerObject1.tag = "Untagged";
        answerObject2.tag = "Untagged";
        answerObject3.tag = "Untagged";
        answerObject4.tag = "Untagged";*/

        // removes the text before setting it again (just to make sure it works)
        answerText1.text = "";
        answerText2.text = "";
        answerText3.text = "";
        answerText4.text = "";
    }

    void SetQuestion(QuestionsSO currentQuestionData)
    {
        // sets the question text
        questionDisplayText.text = currentQuestionData.question;
        questionText.text = currentQuestionData.question;
    }

    void SetAnswers(QuestionsSO currentQuestionData)
    {
        if (currentQuestionData.allCorrect && !currentQuestionData.pointClick)// true and false
        {
            AllCorrectAsnwers(currentQuestionData.correctAnswerList);// sets 4 correct answers
        }
        else if (!currentQuestionData.allCorrect && currentQuestionData.pointClick)//false and true
        {
            PointAndClick(currentQuestionData.pointClickObjects);// sets the pointAndClick answers active
        }
        else
        {
            OneCorrectAnswer(currentQuestionData.wrongAnswerList, currentQuestionData.correctAnswerList);// sets 1 correct answer and 3 wrong answers
        }
    }
    void AllCorrectAsnwers(List<string> correctAnswerList)
    {
        correctListAmount = new List<int> { }; // makes list

        for (int i = 0; i < correctAnswerList.Count; i++)// puts all the indexes from correctAnswerList into the list
        {
            correctListAmount.Add(i);
        }

        // sets the 4 correct answers
        SetCorrectAnswer(answerText1, answerObject1, correctAnswerList);
        SetCorrectAnswer(answerText2, answerObject2, correctAnswerList);
        SetCorrectAnswer(answerText3, answerObject3, correctAnswerList);
        SetCorrectAnswer(answerText4, answerObject4, correctAnswerList);
    }

    void OneCorrectAnswer(List<string> wrongAnswerList, List<string> correctAnswerList)
    {
        int correctAnswer = Random.Range(1, 4); // makes a random between 1 and 4
        correctListAmount = new List<int>(); // makes 2 lists
        wrongListAmount = new List<int>();
        for (int i = 0; i < correctAnswerList.Count; i++) // puts all the indexes from correctAnswerList into the list
        {
            correctListAmount.Add(i);
        }
        for (int i = 0; i < wrongAnswerList.Count; i++) // puts all the indexes from wrongAnswerList into the list
        {
            wrongListAmount.Add(i);
        }

        if (correctAnswer == 1) // if the random is 1
        {
            RemoveTextAndTags(); // removes the text
            SetCorrectAnswer(answerText1, answerObject1, correctAnswerList); // sets the correct answer

            // sets 3 wrong answers
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
        }
        else if (correctAnswer == 2) // if the random is 2
        {
            RemoveTextAndTags(); // removes the text
            SetCorrectAnswer(answerText2, answerObject2, correctAnswerList);// sets the correct answer

            // sets 3 wrong answers
            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
        }
        else if (correctAnswer == 3) // if the random is 3
        {
            RemoveTextAndTags(); // removes the text
            SetCorrectAnswer(answerText3, answerObject3, correctAnswerList);// sets the correct answer

            // sets 3 wrong answers
            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
        }
        else if (correctAnswer == 4) // if the random is 4
        {
            RemoveTextAndTags(); // removes the text
            SetCorrectAnswer(answerText4, answerObject4, correctAnswerList);// sets the correct answer

            // sets 3 wrong answers
            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
        }
    }

    void SetCorrectAnswer(Text answerText, GameObject answerObject, List<string> correctAnswerList)
    {
        int randomCorrectAnswer = Random.Range(0, correctListAmount.Count); // makes a random
        answerText.text = correctAnswerList[correctListAmount[randomCorrectAnswer]]; // answertext.text = all correct answer[all of the indexes [ random answer]]
        correctListAmount.RemoveAt(randomCorrectAnswer); // removes the index that i used to set the answer so i dont use it again
        answerObject.tag = "Correct"; // set the tag of the object
    }

    void SetWrongAnswer(Text answerText, GameObject answerObject, List<string> wrongAnswerList)
    {
        int randomWrongAnswer = Random.Range(0, wrongListAmount.Count);
        answerText.text = wrongAnswerList[wrongListAmount[randomWrongAnswer]]; // answertext.text = all wrong answer[all of the indexes [ random answer]]
        wrongListAmount.RemoveAt(randomWrongAnswer); // removes the index that i used to set the answer so i dont use it again
        answerObject.tag = "Wrong"; // set the tag of the object
    }

    void PointAndClick(List<GameObject> pointClickObjects)
    {
        for (int i = 0; i < pointClickObjects.Count; i++) // gets all the pointclick objects and sets them to true
        {
            pointClickObjects[i].SetActive(true);
        }
    }
}