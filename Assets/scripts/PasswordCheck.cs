using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PasswordCheck : MonoBehaviour
{
    public TMP_InputField passwordInputField; // Reference to the TMP InputField
    public string correctPassword = "IRIS"; // The correct password
    // to asssign the VR button in Inspector
    public Button enterButton;
   
    public GameObject lift;
    public GameObject tile;

    public Collider LiftCollider;
    // Method to check if the password is correct
     void Start()
    {
        
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
    public void CheckPassword()
    {
        if (passwordInputField != null)
        {


            // Get the text entered in the TMP_InputField
            string enteredPassword = passwordInputField.text;

            // Check if the entered password matches the correct password
            if (enteredPassword == correctPassword)
            {
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
