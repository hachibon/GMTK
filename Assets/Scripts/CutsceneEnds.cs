using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneEnds : MonoBehaviour
{
    private VideoPlayer vid;
    [SerializeField] float videoL;
    [SerializeField] GameObject controller;
    [SerializeField] string thisCutscene;
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(videoLength());
    }
    
    IEnumerator videoLength()
    {
        yield return new WaitForSeconds(videoL);
        if (thisCutscene.Equals("initialCutscene"))
        {
            controller.GetComponent<SceneSwitcher>().GotoLevel1();
        }
        if (thisCutscene.Equals("endCutscene"))
        {
            controller.GetComponent<SceneSwitcher>().GotoTitleScene();
        }
    }

}
