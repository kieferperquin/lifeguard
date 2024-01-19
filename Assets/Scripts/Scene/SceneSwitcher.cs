using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
