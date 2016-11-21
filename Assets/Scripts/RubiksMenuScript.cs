using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class RubiksMenuScript : MonoBehaviour {


    public Canvas RubiksCanvas; 

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
