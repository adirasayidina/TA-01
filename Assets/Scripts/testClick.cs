using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testClick : MonoBehaviour
{
   private Renderer _renderer;
   public GameObject txt;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Click!");
        txt.gameObject.SetActive(true);
        Debug.Log(txt.gameObject.activeSelf);
    }

}
