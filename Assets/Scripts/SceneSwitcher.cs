using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{    
    [SerializeField] Button Archives;

    public void GotoTitleScene()
    {
        SceneManager.LoadScene("Title");
        //Archives.IsInteractable();
    }

    public void GotoStart()
    {
        SceneManager.LoadScene("StartTongvaSteps");
    }

    public void GotoLevel()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void GotoEnding()
    {
        SceneManager.LoadScene("Ending");
    }
}
