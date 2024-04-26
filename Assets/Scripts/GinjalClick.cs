using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GinjalClick : MonoBehaviour
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
        if (!StaticClass.objClicked)
        {
            txt.SetActive(true);
            btnCloseUI.SetActive(true);
            StaticClass.objClicked = true;
            StartCoroutine(FlashObject());
        }

    }

    public void OnMouseDown2(string tag)
    {
        ginjalPart = GameObject.FindGameObjectsWithTag(tag);
        print(ginjalPart.Length);
        foreach (GameObject gjl in ginjalPart)
        {
            material = gjl.GetComponent<Renderer>().material;
            material.EnableKeyword("_EMISSION");

            if (!StaticClass.objClicked)
            {
                txt.SetActive(true);
                btnCloseUI.SetActive(true);
                StaticClass.objClicked = true;
                MonoBehaviour camMono = Camera.main.GetComponent<MonoBehaviour>();
                camMono.StartCoroutine(FlashObject());
            }
        }

    }

    IEnumerator FlashObject()
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
                    redCol += 25;
                    greenCol += 25;
                    blueCol += 25;
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
                    redCol -= 25;
                    greenCol -= 25;
                    blueCol -= 25;
                    material.SetColor("_EmissionColor", new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255));
                    material.EnableKeyword("_EMISSION");
                }
            }
        }
        material.SetColor("_EmissionColor", new Color32(0, 0, 0, 0));
    }

}
