using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{

    public Canvas MainCanvas;

    // starts before the start-Function
    void Awake()
    {
        MainCanvas.enabled = true;
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
    }


    //later

    public void loadGame()
    {
        MainCanvas.enabled = false;

    }


}

