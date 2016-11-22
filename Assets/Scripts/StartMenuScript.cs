using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{

    public Canvas MainCanvas;
    public Canvas SettingsCanvas;
    public Canvas ControlsCanvas;

    // starts before the start-Function
    void Awake()
    {
        MainCanvas.enabled = true;
        SettingsCanvas.enabled = false;
        ControlsCanvas.enabled = false;
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        MainCanvas.enabled = false;
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        MainCanvas.enabled = false;
        SettingsCanvas.enabled = true; 
    }

    public void ReturnToMenuButton()
    {
        SettingsCanvas.enabled = false;
        MainCanvas.enabled = true;
    }

    public void ControlsButton()
    {
        SettingsCanvas.enabled = false;
        ControlsCanvas.enabled = true;
    }

    public void ReturnToSettingsButton()
    {
        ControlsCanvas.enabled = false;
        SettingsCanvas.enabled = true;
    }

    //later

    public void loadGame()
    {
        MainCanvas.enabled = false;

    }


}

