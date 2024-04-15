using UnityEngine;

public class ClosePopUp : MonoBehaviour
{
    public GameObject[] penjelasan;
    public GameObject[] objects;

    public void HideUI()
    {
        StaticClass.objClicked = false;
        foreach (GameObject txt in penjelasan) {
            txt.SetActive(false);
        }
    }
}
