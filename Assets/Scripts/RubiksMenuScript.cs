using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class RubiksMenuScript : MonoBehaviour {


    public Canvas RubiksCanvas;
    public Canvas SettingsCanvas;
    public Canvas ControlsCanvas;

    void Awake()
    {
        RubiksCanvas.enabled = true;
        SettingsCanvas.enabled = false;
        ControlsCanvas.enabled = false;
    }


    public void ScrambleButton()
    {
        RubiksCanvas.enabled = false;
    }

    public void SolveButton()
    {
        RubiksCanvas.enabled = false;
    }


    public void ReturnToGameButton()
    {
        RubiksCanvas.enabled = false;
        SceneManager.LoadScene(1);
    }

    public void SettingsButton()
    {
        RubiksCanvas.enabled = false;
        SettingsCanvas.enabled = true;
    }

    public void ReturnToMenuButton()
    {
        SettingsCanvas.enabled = false;
        RubiksCanvas.enabled = true;
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

    public void ExitGameButton()
    {
        Application.Quit();
    }

    //later
    public void saveGame()
    {

    }

    public void loadGame()
    {

    }




}
