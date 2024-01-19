using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class QuestionHandeler : MonoBehaviour
{
    [SerializeField] private QuestionMenuHandeler functionQuestionMenuHandeler;
    [SerializeField] private VideoClipCycle functionVideoClipCycle;
    [SerializeField] private VideoPauze functionVideoPauze;
    [SerializeField] private MenuToVideoSwitch functionMenuToVideoSwitch;
    [SerializeField] private ProgressBarManager functionProgressBarManager;
    [SerializeField] private ScoreManager functionScoreManager;

    [SerializeField] private QuestionsSO[] questionsDataArray;

    [SerializeField] private GameObject questionAnswerBoard, questionObject, pointClickQuestionObject;

    [SerializeField] private Text questionDisplayText, pointClickQuestionText, questionText;

    [SerializeField] private List<GameObject> answerObjects = new List<GameObject>();

    private List<int> correctListAmount;
    private List<int> wrongListAmount;

    private int currentData = 0;

    [SerializeField] private Text debug;
    void Start()
    {
        //run once so in the start you have a question
        SetNextQuestion();

        functionVideoClipCycle.StopClip();
    }

    public void SetNextQuestion()
    {
        if (currentData >= questionsDataArray.Length)
        {
            functionMenuToVideoSwitch.Win();
            functionScoreManager.SetEndingText();
        }

        setAnswerObjectsActive(true);

        functionVideoClipCycle.SetClip(questionsDataArray[currentData]);

        functionQuestionMenuHandeler.SetDisplayVar(false); //set display activated to false so when you answer the menu does not stay open

        SetQuestion(questionsDataArray[currentData]); //sets the question text

        SetAnswers(questionsDataArray[currentData]); //sets the answers

        functionProgressBarManager.SetBarSize(currentData, questionsDataArray.Length);

        currentData++;
    }

    void SetTextAndTags(string tagToSet, string textToSet)
    {
        for (int i = 0; i < answerObjects.Count; i++)
        {
            answerObjects[i].tag = tagToSet;
        }

        for (int i = 0; i < answerObjects.Count; i++)
        {
            answerObjects[i].GetComponentInChildren<Text>().text = textToSet;
        }
    }

    void SetQuestion(QuestionsSO currentQuestionData)
    {
        // sets the question text
        questionDisplayText.text = currentQuestionData.question;
        questionText.text = currentQuestionData.question;
        pointClickQuestionText.text = currentQuestionData.question;
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

    void setAnswerObjectsActive(bool active)
    {
        questionObject.SetActive(active);
        pointClickQuestionObject.SetActive(!active);
    }

    void AllCorrectAsnwers(List<string> correctAnswerList)
    {
        correctListAmount = new List<int> { }; // makes list

        for (int i = 0; i < correctAnswerList.Count; i++)// puts all the indexes from correctAnswerList into the list
        {
            correctListAmount.Add(i);
        }

        for (int i = 0; i < answerObjects.Count; i++)
        {
            SetCorrectAnswer(answerObjects[i], correctAnswerList);
        }
    }

    void OneCorrectAnswer(List<string> wrongAnswerList, List<string> correctAnswerList)
    {
        List<int> answers = new List<int>() { 0, 1, 2, 3};

        int correctAnswer = Random.Range(1, answers.Count); // makes a random between 1 and 4

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
        SetTextAndTags("Untagged", "");

        SetCorrectAnswer(answerObjects[correctAnswer], correctAnswerList); // sets the correct answer
        answers.Remove(correctAnswer);

        while(answers.Count > 0)
        {
            SetWrongAnswer(answerObjects[answers[0]], wrongAnswerList);
            answers.Remove(answers[0]);
        }
    }

    void SetCorrectAnswer(GameObject answerObject, List<string> correctAnswerList)
    {
        int randomCorrectAnswer = Random.Range(0, correctListAmount.Count); // makes a random
        answerObject.GetComponentInChildren<Text>().text = correctAnswerList[correctListAmount[randomCorrectAnswer]]; // answertext.text = all correct answer[all of the indexes [ random answer]]
        correctListAmount.RemoveAt(randomCorrectAnswer); // removes the index that i used to set the answer so i dont use it again
        answerObject.tag = "Correct"; // set the tag of the object
    }

    void SetWrongAnswer(GameObject answerObject, List<string> wrongAnswerList)
    {
        int randomWrongAnswer = Random.Range(0, wrongListAmount.Count); // makes a random
        answerObject.GetComponentInChildren<Text>().text = wrongAnswerList[wrongListAmount[randomWrongAnswer]]; // answertext.text = all wrong answer[all of the indexes [ random answer]]
        wrongListAmount.RemoveAt(randomWrongAnswer); // removes the index that i used to set the answer so i dont use it again
        answerObject.tag = "Wrong"; // set the tag of the object
    }

    void PointAndClick(GameObject pointClickObject)
    {
        setAnswerObjectsActive(false);

        functionQuestionMenuHandeler.SetPointClickQuestionGameObject(Instantiate(pointClickObject, new Vector3(0, 0, 0), Quaternion.identity));
        functionQuestionMenuHandeler.SetDisplayVar(false);
    }

    public QuestionsSO GiveQuestionsData()
    {
        return questionsDataArray[currentData -1];
    }
}