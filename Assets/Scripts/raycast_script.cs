using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Debug = UnityEngine.Debug;

public class raycast_script : MonoBehaviour
{
    public GameObject obj;
    public string targetTag;
    Vector2 firstTouch;
    Vector2 secondTouch;
    float distCurrent;
    float distPrev;
    bool firstClick = true;
    public float rotatespeed = 0.05f;
    private Vector2 oldTouchPosition;
    private Vector2 NewTouchPosition;
    private Quaternion rotationY;
    private Vector2 initialTouch1Position;
    private Vector2 initialTouch2Position;
    private float initialDistance;
    private float initialScale;
    private float zoomSpeed = 0.001f;
    private GameObject[] objectsWithTag;

    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);
        if (Input.touchCount == 1 && !StaticClass.objClicked)
        {
            Touch touch = Input.GetTouch(0);
            //switch (touch.phase)
            //{
            //    //case TouchPhase.Began:
            //    //    oldTouchPosition = touch.position;
            //    //    break;
            if (touch.phase == TouchPhase.Moved)
            {
                if (objectsWithTag != null)
                {
                    foreach (GameObject objs in objectsWithTag)
                    {
                        rotationY = Quaternion.Euler(0f, (-touch.deltaPosition.x / Mathf.Abs(touch.deltaPosition.x)) * rotatespeed, 0f);
                        objs.transform.rotation = rotationY * objs.transform.rotation;
                    }
                }
            }
                    
                    //NewTouchPosition = touch.position;
                    //Vector2 rotDirection = oldTouchPosition - NewTouchPosition;
                    //Debug.Log(rotDirection);
                    //if (rotDirection.x < 0)
                    //    RotateRight();
                    //if (rotDirection.x > 0)
                    //    RotateLeft();
                    //break;
                    //}
            
        }
        if (Input.touchCount > 1 && !StaticClass.objClicked)
        {
            Debug.Log("Number of objects found with tag: " + objectsWithTag.Length);
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch2.phase == TouchPhase.Began)
            {
                initialTouch1Position = touch1.position - touch1.deltaPosition;
                initialTouch2Position = touch2.position - touch2.deltaPosition;
                initialDistance = Vector2.Distance(initialTouch1Position, initialTouch2Position);
                initialScale = GetAverageScale();
            }
            else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
            {
                Vector2 currentTouch1Position = touch1.position - touch1.deltaPosition;
                Vector2 currentTouch2Position = touch2.position - touch2.deltaPosition;
                float currentDistance = Vector2.Distance(currentTouch1Position, currentTouch2Position);
                float pinchAmount = initialDistance - currentDistance;

                // Apply the zoom to tagged objects
                GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
                foreach (GameObject obj in taggedObjects)
                {
                    float newScale = initialScale - pinchAmount * zoomSpeed;
                    obj.transform.localScale = new Vector3(newScale, newScale, newScale);
                }
            }
            //firstTouch = Input.GetTouch(0).position;
            //print(firstTouch);
            //secondTouch = Input.GetTouch(1).position;
            //print(secondTouch);
            //distCurrent = secondTouch.magnitude - firstTouch.magnitude;
            //if (firstClick)
            //{
            //    firstClick = false;
            //    distPrev = distCurrent;
            //}
            //if (distCurrent != distPrev)
            //{
            //    foreach (GameObject objs in objectsWithTag)
            //    {
            //        Debug.Log("Object name: " + objs.name);
            //        Vector3 scale_value = objs.transform.localScale * (distCurrent / distPrev);
            //        distPrev = distCurrent;
            //        objs.transform.localScale += scale_value;
            //    }

            //}
        }
        else if (!StaticClass.objClicked)
        {
            firstClick = true;
        }
    }

    void RotateLeft()
    {
        transform.rotation = Quaternion.Euler(0f, -rotatespeed, 0f) * transform.rotation;
    }

    void RotateRight()
    {
        transform.rotation = Quaternion.Euler(0f, rotatespeed, 0f) * transform.rotation;
    }

    private float GetAverageScale()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
        float totalScale = 0f;
        foreach (GameObject obj in taggedObjects)
        {
            totalScale += obj.transform.localScale.x;
        }
        return totalScale / taggedObjects.Length;
    }
}