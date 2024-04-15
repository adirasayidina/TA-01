using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class raycast_script : MonoBehaviour
{
    public GameObject obj;
    Vector2 firstTouch;
    Vector2 secondTouch;
    float distCurrent;
    float distPrev;
    bool firstClick = true;
    public float rotatespeed = 0.05f;
    private Vector2 oldTouchPosition;
    private Vector2 NewTouchPosition;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && !StaticClass.objClicked)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    oldTouchPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    NewTouchPosition = touch.position;
                    Vector2 rotDirection = oldTouchPosition - NewTouchPosition;
                    Debug.Log(rotDirection);
                    if (rotDirection.x < 0)
                        RotateRight();
                    if (rotDirection.x > 0)
                        RotateLeft();
                    break;
            }
        }
        if (Input.touchCount > 1 && !StaticClass.objClicked)
        {
            firstTouch = Input.GetTouch(0).position;
            print(firstTouch);
            secondTouch = Input.GetTouch(1).position;
            print(secondTouch);
            distCurrent = secondTouch.magnitude - firstTouch.magnitude;
            if (firstClick)
            {
                firstClick = false;
                distPrev = distCurrent;
            }
            if (distCurrent != distPrev)
            {
                Vector3 scale_value = obj.transform.localScale * (distCurrent / distPrev);
                distPrev = distCurrent;
                obj.transform.localScale = scale_value;

            }
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
}