using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public void GinjalMenu()
    {
        SceneManager.LoadScene("ObjectScene");
    }

    public void GinjalBack()
    {
        SceneManager.LoadScene("Menu");
    }

        public void GinjalQuiz()
    {
    SceneManager.LoadScene("Quiz");
    }
}
