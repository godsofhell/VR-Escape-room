using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("All Menu's")]
    // MenuUI is a game object which contains all the UI elements such as resume , menu, Quit
    public GameObject pauseMenuUI;
    public static bool GameIsStopped = false;

    // when resume button is pressed then pause menu UI goes away and the time scale is back to normal
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsStopped = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsStopped = true;
    }
    // if player presses restart button
    public void Restart()
    {
        SceneManager.LoadScene("scene_night");
        Time.timeScale = 1f;
    }
    // if player presses menu button back to garage scene
    public void LoadMenu()
    {
        SceneManager.LoadScene("Garage");
        Time.timeScale = 1f;
    }
    // to quit game
    public void QuitGame()
    {
        Application.Quit();
    }


}
