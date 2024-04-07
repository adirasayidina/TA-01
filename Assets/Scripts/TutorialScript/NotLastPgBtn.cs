using UnityEngine;
using UnityEngine.UI;

public class NotLastPgBtn : MonoBehaviour
{
    // Reference to the UI Button
    public Image btnLanjutkan;
    public Image btnSkip;

    // Method to set the visibility of the button
    public void SetButtonVisibility(bool isVisible)
    {
        // Set the visibility of the button
        btnLanjutkan.gameObject.SetActive(isVisible);
        btnSkip.gameObject.SetActive(isVisible);
    }
}
