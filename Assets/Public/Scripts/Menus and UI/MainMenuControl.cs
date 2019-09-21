using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Continue()
    {
        SceneManager.LoadScene("SampleScene");
        // TODO: Need to load from a save
    }

    public void Options()
    {
        // TODO: Add Options scene
    }

    public void Credits()
    {
        // TODO: Add Credits scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
