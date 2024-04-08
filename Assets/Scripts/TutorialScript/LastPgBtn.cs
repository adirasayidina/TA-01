using UnityEngine;
using UnityEngine.UI;

public class LastPgBtn : MonoBehaviour
{
    // Reference to the UI Button
    public Image uiButton;

    // Method to set the visibility of the button
    public void SetButtonVisibility(bool isVisible)
    {
        // Set the visibility of the button
        uiButton.gameObject.SetActive(isVisible);
    }

    public void setViewedTutorial()
    {
        PlayerPrefs.SetInt("FirstTime", 1);
    }
}
