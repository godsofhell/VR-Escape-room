using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PasswordCheck : MonoBehaviour
{
    public TMP_InputField passwordInputField; // Reference to the TMP InputField
    public TMP_Text correctPassword;
    
    // The correct password
    // to asssign the VR button in Inspector
    public Button enterButton;
   
    public GameObject lift;
    public GameObject tile;
    public GameObject NPC;

    public Collider LiftCollider;

    

    public TMP_Text digit1;
    public TMP_Text digit2;
    public TMP_Text digit3;

    private int[] passwordDigits;
    public Transform[] digitLocations;

    public TMP_Text textPrefab;

    private int password;
    
    // Method to check if the password is correct
     void Start()
    {
        GeneratePassword();
        DisplayDigits();
        tile.SetActive(false);
        lift.SetActive(false);

        if(enterButton != null )
        {
            enterButton.onClick.AddListener(CheckPassword);
        }
        else
        {
            Debug.Log("Enter Button is not assigned");
        }

    }
    public void GeneratePassword()
    {
        int password = Random.Range(100, 999);
        correctPassword.text = password.ToString();
        Debug.Log("generated password" + password);

        passwordDigits = new int[3];
        passwordDigits[0] = password / 100;
        passwordDigits[1] = (password / 10) % 10;
        passwordDigits[2] = password % 10;
        
    }
    public void DisplayDigits()
    {
        digit1.text = passwordDigits[0].ToString();
        digit2.text = passwordDigits[1].ToString();
        digit3.text = passwordDigits[2].ToString();

        for(int i=0;i<passwordDigits.Length; i++)
        {
            TMP_Text digitText = Instantiate(textPrefab, digitLocations[i].position, Quaternion.identity);
            digitText.text = passwordDigits[i].ToString();
        }
    }
    public void CheckPassword()
    {
        
        if (passwordInputField != null)
        {


            // Get the text entered in the TMP_InputField
            string enteredPassword = passwordInputField.text;

            // Check if the entered password matches the correct password
            if (enteredPassword == correctPassword.text)
            {
                NPC.SetActive(true);
                LiftCollider.isTrigger = true;
                lift.SetActive(true);
                tile.SetActive(true);

                Debug.Log("password is correct"); // Optional: Change the color of the result text
            }
        }
        else
        {
            Debug.Log("password is incorrect"); // Optional: Change the color of the result text
        }
    }
}
