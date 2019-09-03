using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void ButtonNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonContinue()
    {
        SceneManager.LoadScene(1);
        // TODO: Need to load from a save
    }

    public void ButtonOptions()
    {
        // TODO: Add Options scene
    }

    public void ButtonCredits()
    {
        // TODO: Add Credits scene
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
