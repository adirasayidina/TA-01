using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public void ObjectMenu(int codeScene)
    {
        if (codeScene == 0)
            SceneManager.LoadScene("ObjectScene");
        else
            SceneManager.LoadScene("ObjectScene");
    }

    public void QuizMenu(int codeScene)
    {
        if (codeScene == 0)
        {
            StaticClass.QuizCode = 0;
            SceneManager.LoadScene("Quiz");
        }
        else
        {
            StaticClass.QuizCode = 1;
            print(StaticClass.QuizCode);
            SceneManager.LoadScene("Quiz");
        }
    }

    public void TutorialMenu()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void HomeMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
