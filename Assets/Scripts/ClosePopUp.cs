using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.EventSystems;

public class ClosePopUp : MonoBehaviour
{
    public GameObject[] buttons;

    public GameObject placementIndicator;
    //private GameObject carParent;

    bool isUIHidden = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void HideUI()
    {

        // foreach (var button in buttons)
        // {
        //     Debug.Log(button.gameObject.activeSelf);
        //     if (button.gameObject.activeSelf)
        //     {
        //         button.gameObject.SetActive(false);
        //     }
        //     Debug.Log(button.gameObject.activeSelf);
        // }
        if (isUIHidden == false)
        {
            Debug.Log("ui hidden false");
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }

            isUIHidden = true;
        }

        else if (isUIHidden == true)
        {
            Debug.Log("ui hidden true");
            // ga tau knp kalo klik object jd nge trigger event click button informasi textnya
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(true);
            }

            isUIHidden = false;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
