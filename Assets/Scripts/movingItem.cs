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
    [SerializeField] GameObject trigger;
    [SerializeField] GameObject moveUI;
    [SerializeField] private CinemachineVirtualCamera diorama;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject instructions;
    
    
    // Start is called before the first frame update
    void Start()
    {
        xScale = transform.localScale.x;
        ogXScale = transform.localScale.x;
        yScale = transform.localScale.y;
        ogYScale = transform.localScale.y;
        zScale = transform.localScale.z;
        ogZScale = transform.localScale.z;
        xPosition = transform.localPosition.x;
        ogXPosition = transform.localPosition.x;
        yPosition = transform.localPosition.y;
        ogYPosition = transform.localPosition.y;
        zPosition = transform.localPosition.z;
        ogZPosition = transform.localPosition.z;
        xRotate = transform.localEulerAngles.x;
        ogXRotate = transform.localEulerAngles.x;
        yRotate = transform.localEulerAngles.y;
        ogYRotate = transform.localEulerAngles.y;
        zRotate = transform.localEulerAngles.z;
        ogZRotate = transform.localEulerAngles.z;
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
                transform.localPosition = new Vector3(xPosition,yPosition,zPosition);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                zPosition = zPosition-changedSizeMove;
                transform.localPosition = new Vector3(xPosition,yPosition,zPosition);
            }
        }
        if(moveY)
        {
            Debug.Log("changedAxis");
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                yPosition = yPosition+changedSizeMove;
                transform.localPosition = new Vector3(xPosition,yPosition,zPosition);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                yPosition = yPosition-changedSizeMove;
                transform.localPosition = new Vector3(xPosition,yPosition,zPosition);
            }
        }
        if(rotateZ)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                zRotate = zRotate+changedSizeRotate;
                transform.localEulerAngles = new Vector3(xRotate, yRotate, zRotate);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                zRotate = zRotate-changedSizeRotate;
                transform.localEulerAngles = new Vector3(xRotate, yRotate, zRotate);
            }
        }
        if(rotateY)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                yRotate = yRotate+changedSizeRotate;
                transform.localEulerAngles = new Vector3(xRotate, yRotate, zRotate);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                yRotate = yRotate-changedSizeRotate;
                transform.localEulerAngles = new Vector3(xRotate, yRotate, zRotate);
            }
        }
        if((Vector3.Distance(transform.position,target.transform.position) <= 1f) && ((Vector3.Distance(transform.localScale,target.transform.localScale)) <= .45f) && (Vector3.Distance(transform.eulerAngles,target.transform.eulerAngles) <= 30f))
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
            transform.localPosition = new Vector3(0,yPosition,zPosition);
            xRotate = ogXRotate;
            yRotate = ogYRotate;
            zRotate = ogZRotate;
            transform.localEulerAngles = new Vector3(xRotate, yRotate, zRotate);
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
        target.SetActive(false);
        yield return new WaitForSeconds(1f);
        //success sound & effect
        //add code to replace old sprite with new sprite
        //add code to delete script from sprite on background control
        diorama.Priority = 0;
        yield return new WaitForSeconds(1f);
        instructions.SetActive(false);
        moveUI.SetActive(true);
        text.SetActive(true);
        foreach(Collider c in trigger.GetComponents<Collider> ()) {
            c.isTrigger = false;
        }
        trigger.GetComponent<Collider>().isTrigger = false;
        Destroy(GetComponent<movingItem>());
    }
}
