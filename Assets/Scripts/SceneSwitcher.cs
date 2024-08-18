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

    public void GotoLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GotoLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void GotoLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void GotoEnding()
    {
        SceneManager.LoadScene("Ending");
    }
}
