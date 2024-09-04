using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    public void StartPlay()
    // this function will concern the operation of the 'start to play' button
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    // this function will concern the operation of the 'quit' button
    {
        Application.Quit();
    }
    public void goOnControls()
    // this function will concern the operation of the 'controls' button
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ReturnToMenu()
    // this function will concern operation of the 'return to menu' button in the controls tab
    {
        SceneManager.LoadSceneAsync(0);
    }

}
