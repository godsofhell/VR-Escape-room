using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private  float currentTime;
    [SerializeField] private float displayTime;
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private GameObject gameOverBox;
    public PasswordCheck Check;
    public ParticleController time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        displayTime = Mathf.Round(currentTime);
        

        if(currentTime <= 0 || Check.count >=3 || time.timer < 0)
        {
            displayText.text = "GAME OVER";
            gameOverBox.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            displayText.text = displayTime.ToString();
        }
    }
}
