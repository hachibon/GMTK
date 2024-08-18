using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class movingItem : MonoBehaviour
{
    private Boolean loadedIn = true;
    [SerializeField] float changedSizeScale = 0.05f;
    [SerializeField] float changedSizeMove = 0.2f;
    [SerializeField] float changedSizeRotate = 3.25f;
    private float xScale, yScale, zScale;
    private float xPosition, yPosition, zPosition;
    private float xRotate, yRotate, zRotate;
    private float ogXScale, ogYScale, ogZScale, ogXPosition, ogYPosition, ogZPosition, ogXRotate, ogYRotate, ogZRotate;
    private Boolean moveZ=false, moveY=false, rotateZ=false, rotateY=false, scale=false;
    private Boolean pressedOnce=false;
    [SerializeField] GameObject target;
    [SerializeField] private CinemachineVirtualCamera diorama;
    [SerializeField] GameObject trigger;
    
    
    // Start is called before the first frame update
    void Start()
    {
        xScale = transform.localScale.x;
        ogXScale = transform.localScale.x;
        yScale = transform.localScale.y;
        ogYScale = transform.localScale.y;
        zScale = transform.localScale.z;
        ogZScale = transform.localScale.z;
        xPosition = transform.position.x;
        ogXPosition = transform.position.x;
        yPosition = transform.position.y;
        ogYPosition = transform.position.y;
        zPosition = transform.position.z;
        ogZPosition = transform.position.z;
        xRotate = transform.eulerAngles.x;
        ogXRotate = transform.eulerAngles.x;
        yRotate = transform.eulerAngles.y;
        ogYRotate = transform.eulerAngles.y;
        zRotate = transform.eulerAngles.z;
        ogZRotate = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            loadedIn = false;
            rotateZ = false;
            rotateY = false;
            moveZ = false;
            moveY = false;
            scale = true;
        }
        if(Input.GetKeyDown(KeyCode.E)&&pressedOnce==false)
        {
            loadedIn = false;
            scale = false;
            moveZ = false;
            moveY = false;
            rotateZ = true;
            rotateY = false;
            StartCoroutine(waitASecPressedOnceTrue());
        }
        if(Input.GetKeyDown(KeyCode.E)&&pressedOnce==true)
        {
            loadedIn = false;
            scale = false;
            moveZ = false;
            moveY = false;
            rotateZ = false;
            rotateY = true;
            StartCoroutine(waitASecPressedOnceFalse());
        }
        if(Input.GetKeyDown(KeyCode.W)&&pressedOnce==false)
        {
            loadedIn = false;
            scale = false;
            rotateZ = false;
            rotateY = false;
            moveY = false;
            moveZ = true;
            StartCoroutine(waitASecPressedOnceTrue());
        }
        if(Input.GetKeyDown(KeyCode.W)&&pressedOnce==true)
        {
            loadedIn = false;
            scale = false;
            rotateZ = false;
            rotateY = false;
            moveZ = false;
            moveY = true;
            StartCoroutine(waitASecPressedOnceFalse());
        }
        if(loadedIn == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                xScale = xScale+changedSizeScale;
                yScale = yScale+changedSizeScale;
                zScale = zScale+changedSizeScale;
                transform.localScale = new Vector3(xScale,yScale,zScale);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                xScale = xScale-changedSizeScale;
                yScale = yScale-changedSizeScale;
                zScale = zScale-changedSizeScale;
                transform.localScale = new Vector3(xScale,yScale,zScale);
            }
        }
        if(scale) //scale keybind
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                xScale = xScale+changedSizeScale;
                yScale = yScale+changedSizeScale;
                zScale = zScale+changedSizeScale;
                transform.localScale = new Vector3(xScale,yScale,zScale);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                xScale = xScale-changedSizeScale;
                yScale = yScale-changedSizeScale;
                zScale = zScale-changedSizeScale;
                transform.localScale = new Vector3(xScale,yScale,zScale);
            }
        }
        if(moveZ)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                zPosition = zPosition+changedSizeMove;
                transform.position = new Vector3(xPosition,yPosition,zPosition);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                zPosition = zPosition-changedSizeMove;
                transform.position = new Vector3(xPosition,yPosition,zPosition);
            }
        }
        if(moveY)
        {
            Debug.Log("changedAxis");
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                yPosition = yPosition+changedSizeMove;
                transform.position = new Vector3(xPosition,yPosition,zPosition);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                yPosition = yPosition-changedSizeMove;
                transform.position = new Vector3(xPosition,yPosition,zPosition);
            }
        }
        if(rotateZ)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                zRotate = zRotate+changedSizeRotate;
                transform.eulerAngles = new Vector3(xRotate, yRotate, zRotate);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                zRotate = zRotate-changedSizeRotate;
                transform.eulerAngles = new Vector3(xRotate, yRotate, zRotate);
            }
        }
        if(rotateY)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                yRotate = yRotate+changedSizeRotate;
                transform.eulerAngles = new Vector3(xRotate, yRotate, zRotate);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                yRotate = yRotate-changedSizeRotate;
                transform.eulerAngles = new Vector3(xRotate, yRotate, zRotate);
            }
        }
        if((Vector3.Distance(transform.position,target.transform.position) <= 1f) && ((Vector3.Distance(transform.localScale,target.transform.localScale)) <= .35f) && (Vector3.Distance(transform.eulerAngles,target.transform.eulerAngles) <= 30f))
        {
            StartCoroutine(lockedInPlace());
        }
        if(Input.GetKeyDown(KeyCode.Q)) //reset position
        {
            xScale = ogXScale;
            yScale = ogYScale;
            zScale = ogZScale;
            transform.localScale = new Vector3(xScale,yScale,zScale);
            xPosition = ogXPosition;
            yPosition = ogYPosition;
            zPosition = ogZPosition;
            transform.position = new Vector3(xPosition,yPosition,zPosition);
            xRotate = ogXRotate;
            yRotate = ogYRotate;
            zRotate = ogZRotate;
            transform.eulerAngles = new Vector3(xRotate, yRotate, zRotate);
        }
    }

    IEnumerator waitASecPressedOnceTrue()
    {
        yield return new WaitForSeconds(1f);
        pressedOnce = true;
    }
    IEnumerator waitASecPressedOnceFalse()
    {
        yield return new WaitForSeconds(1f);
        pressedOnce = false;
    }

    IEnumerator lockedInPlace()
    {
        loadedIn = false;
        scale = false;
        rotateZ = false;
        rotateY = false;
        moveY = false;
        moveZ = false;
        yield return new WaitForSeconds(1f);
        //success sound & effect
        //add code to replace old sprite with new sprite
        diorama.Priority = 0;
        trigger.SetActive(false);
    }
}
