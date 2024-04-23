using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneBehaviour : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (!PlayerPrefs.HasKey("Nama"))
        {
            SceneManager.LoadScene("IsiNama");
        }
    }
}
