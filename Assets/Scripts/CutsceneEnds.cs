using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneEnds : MonoBehaviour
{
    [SerializeField] float videoL;
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(videoLength());
    }
    
    IEnumerator videoLength()
    {
        yield return new WaitForSeconds(videoL);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
