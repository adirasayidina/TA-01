using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestNextQ : MonoBehaviour
{
    static public int lastScene = 0;
    // Start is called before the first frame update
    void Start()
    {
     print(lastScene);   
     print(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextQ(int code) {
        lastScene = code;
    }

    public void P() {
        print(lastScene);
    }
}
