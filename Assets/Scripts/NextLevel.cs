using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] int numOfPieces;
    [SerializeField] public int amtDone = 0;
    private AudioSource sigh;
    private CinemachineVirtualCamera diorama;
    
    void Start()
    {
        sigh = GameObject.Find("sigh").GetComponent<AudioSource>();
        diorama = GameObject.Find("VirtualCameraForPiecingTogether").GetComponent<CinemachineVirtualCamera>();
    }

    void FixedUpdate()
    {
        if(amtDone == numOfPieces)
        {
            StartCoroutine(FinishedLevel());
            amtDone++;
        }
    }
    IEnumerator FinishedLevel()
    {
        diorama.Priority = 4;
        sigh.Play();
        yield return new WaitForSeconds(5f);
        //SFX
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
