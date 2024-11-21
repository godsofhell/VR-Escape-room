using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayAgain()
    {
        SceneManager.LoadScene("outpost with snow");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
