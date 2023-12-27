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

    [SerializeField] private GameObject questionAnswerBoard;

    [SerializeField] private Text questionDisplayText, questionText;
    [SerializeField] private GameObject answerObject1, answerObject2, answerObject3, answerObject4;
    private Text answerText1, answerText2, answerText3, answerText4;

    private List<int> correctListAmount;
    private List<int> wrongListAmount;

    private int currentData = 0;

    [SerializeField] private Text debug;
    void Start()
    {        
        //get text objects from buttons
        answerText1 = answerObject1.GetComponentInChildren<Text>();
        answerText2 = answerObject2.GetComponentInChildren<Text>();
        answerText3 = answerObject3.GetComponentInChildren<Text>();
        answerText4 = answerObject4.GetComponentInChildren<Text>();

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
        answerObject1.tag = tagToSet;
        answerObject2.tag = tagToSet;
        answerObject3.tag = tagToSet;
        answerObject4.tag = tagToSet;

        answerText1.text = textToSet;
        answerText2.text = textToSet;
        answerText3.text = textToSet;
        answerText4.text = textToSet;
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

    void setAnswerObjectsActive(bool active)
    {
        answerObject1.SetActive(active);
        answerObject2.SetActive(active);
        answerObject3.SetActive(active);
        answerObject4.SetActive(active);
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

        SetTextAndTags("Untagged", "");

        if (correctAnswer == 1) // if the random is 1
        {
            SetCorrectAnswer(answerText1, answerObject1, correctAnswerList); // sets the correct answer

            // sets 3 wrong answers
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
        }
        else if (correctAnswer == 2) // if the random is 2
        {
            SetCorrectAnswer(answerText2, answerObject2, correctAnswerList);// sets the correct answer

            // sets 3 wrong answers
            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            SetWrongAnswer(answerText3, answerObject3, wrongAnswerList);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
        }
        else if (correctAnswer == 3) // if the random is 3
        {
            SetCorrectAnswer(answerText3, answerObject3, correctAnswerList);// sets the correct answer

            // sets 3 wrong answers
            SetWrongAnswer(answerText1, answerObject1, wrongAnswerList);
            SetWrongAnswer(answerText2, answerObject2, wrongAnswerList);
            SetWrongAnswer(answerText4, answerObject4, wrongAnswerList);
        }
        else if (correctAnswer == 4) // if the random is 4
        {
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
        int randomWrongAnswer = Random.Range(0, wrongListAmount.Count); // makes a random
        answerText.text = wrongAnswerList[wrongListAmount[randomWrongAnswer]]; // answertext.text = all wrong answer[all of the indexes [ random answer]]
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