using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pnlTutorial;
    public GameObject pnlIsiNama;
    void Start()
    {
        if (PlayerPrefs.HasKey("Nama"))
        {
            pnlTutorial.SetActive(true);
            pnlIsiNama.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
