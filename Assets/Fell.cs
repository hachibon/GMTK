using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fell : MonoBehaviour
{
    private float xPosition, yPosition, zPosition;
    [SerializeField] private GameObject player;

    void Start()
    {
        xPosition = player.transform.localPosition.x;
        yPosition = player.transform.localPosition.y;
        zPosition = player.transform.localPosition.z;
    }
    
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.localPosition = new Vector3(xPosition,yPosition,zPosition);
        }
    }
}
