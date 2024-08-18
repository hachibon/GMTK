using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingItem : MonoBehaviour
{
    private string currentAxis = "X axis";
    private Boolean loadedIn = true;
    [SerializeField] float changedSize = 0.05f;
    float x1, y1, z1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        x1 = transform.localScale.x;
        y1 = transform.localScale.y;
        z1 = transform.localScale.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(loadedIn == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                x1 = x1+changedSize;
                y1 = y1+changedSize;
                z1 = z1+changedSize;
                transform.localScale = new Vector3(x1,y1,z1);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                x1 = x1-changedSize;
                y1 = y1-changedSize;
                z1 = z1-changedSize;
                transform.localScale = new Vector3(x1,y1,z1);
            }
        }
        if(Input.GetKeyDown(KeyCode.R)) //scale keybind
        {
            loadedIn = false;
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                x1 = x1+changedSize;
                y1 = y1+changedSize;
                z1 = z1+changedSize;
                transform.localScale = new Vector3(x1,y1,z1);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                x1 = x1-changedSize;
                y1 = y1-changedSize;
                z1 = z1-changedSize;
                transform.localScale = new Vector3(x1,y1,z1);
            }
        }
    }
}
