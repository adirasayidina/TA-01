using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Image = UnityEngine.UI.Image;

public class LastPgBtn : MonoBehaviour
{
    // Reference to the UI Button
    public Image btnMulaiBelajar;
    public InputField fieldNama;
    //public GameObject pnlIsiNama;

    // Method to set the visibility of the button
    public void SetButtonVisibility(bool isVisible)
    {
        // Set the visibility of the button
        btnMulaiBelajar.gameObject.SetActive(isVisible);
    }

    public void setViewedTutorial()
    {
        PlayerPrefs.SetInt("FirstTime", 1);
    }

    public void setName()
    {
        PlayerPrefs.SetString("Nama", fieldNama.text);
    }
}
