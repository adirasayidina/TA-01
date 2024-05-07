using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class GinjalClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject txt;
    public GameObject btnCloseUI;
    public GameObject[] ginjalPart;
    private Material material;
    public int redCol;
    public int blueCol;
    public int greenCol;
    public bool flashingIn = true;
    public string targetTag;
    private GameObject[] objectsWithTag;
    private GameObject instantiatedObject;
    private Vector2 oldTouchPosition;
    private Vector2 NewTouchPosition;

    private void Start()
    {
        // _renderer = GetComponent<Renderer>();
        // material = ginjalPart.GetComponent<Renderer>().material;
        // // print("masuk mulai");
        // material.EnableKeyword("_EMISSION");
        // print(material.GetColor("_EmissionColor"));
    }

    public void OnMouseDown()
    {
        if (Input.touchCount == 1)
        {

            oldTouchPosition = Input.GetTouch(0).position;
        }
        //StartFlash();
    }

    // public void OnMouseUp()
    // {
    //     // NewTouchPosition = Input.GetTouch(0).position;
    //     // float distance = Vector2.Distance(oldTouchPosition, NewTouchPosition);
    //     // if (distance < 10f)
    //     // {
    //     //     print("Tap detected!");
    //     //     StartFlash();
    //     // }

    // }

    public void SetObjectClicked()
    {
        StaticClass.objClicked = true;
    }

    public void OnMouseDown2(string tag)
    {
        ginjalPart = GameObject.FindGameObjectsWithTag(tag);
        StartFlash();
    }

    private void StartFlash()
    {
        txt.SetActive(true);
        btnCloseUI.SetActive(true);
        if (!StaticClass.objClicked)
        {
            StaticClass.objClicked = true;
            foreach (GameObject gjl in ginjalPart)
            {

                material = gjl.GetComponent<Renderer>().material;
                material.EnableKeyword("_EMISSION");
                StartCoroutine(FlashObject(material));
            }

        }
    }

    IEnumerator FlashObject(Material material)
    {
        // print("masuk flash obj");
        while (StaticClass.objClicked)
        {
            yield return new WaitForSeconds(0.05f);
            if (flashingIn)
            {
                if (greenCol >= 250)
                    flashingIn = false;
                else
                {
                    redCol += 25 / ginjalPart.Length;
                    greenCol += 25 / ginjalPart.Length;
                    blueCol += 25 / ginjalPart.Length;
                    material.SetColor("_EmissionColor", new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255));
                    material.EnableKeyword("_EMISSION");
                }
            }
            else
            {
                if (greenCol <= 5)
                    flashingIn = true;
                else
                {
                    redCol -= 25 / ginjalPart.Length;
                    greenCol -= 25 / ginjalPart.Length;
                    blueCol -= 25 / ginjalPart.Length;
                    material.SetColor("_EmissionColor", new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255));
                    material.EnableKeyword("_EMISSION");
                }
            }
        }
        material.SetColor("_EmissionColor", new Color32(0, 0, 0, 0));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        NewTouchPosition = Input.GetTouch(0).position;
        float distance = Vector2.Distance(oldTouchPosition, NewTouchPosition);
        if (distance < 10f)
        {
            print("Tap detected!");
            StartFlash();
        }
    }
}
