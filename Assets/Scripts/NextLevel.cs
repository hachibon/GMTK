using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] int numOfPieces;
    [SerializeField] public int amtDone = 0;

    // Update is called once per frame
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
        yield return new WaitForSeconds(1f);
        //SFX
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
