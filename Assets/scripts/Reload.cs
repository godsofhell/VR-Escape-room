using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ProceduralGeneration procGen;
    public AudioSource speak;
    private void Start()
    {
        procGen = GetComponent<ProceduralGeneration>();
        speak = GetComponent<AudioSource>();
        speak.Play();
    }
    public static Reload Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void PlayAgain()
    {
       // procGen.GenerateObject();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}


