using UnityEngine;
using TMPro;

public class PasswordCheck : MonoBehaviour
{
    public TMP_InputField passwordInputField; // Reference to the TMP InputField
    public string correctPassword = "IRIS"; // The correct password
    public TextMeshProUGUI resultText; // Reference to a TMP Text for displaying results

    // Method to check if the password is correct
    public void CheckPassword()
    {
        // Get the text entered in the TMP_InputField
        string enteredPassword = passwordInputField.text;

        // Check if the entered password matches the correct password
        if (enteredPassword == correctPassword)
        {
            resultText.text = "Password is correct!";
            resultText.color = Color.green; // Optional: Change the color of the result text
        }
        else
        {
            resultText.text = "Incorrect password. Try again.";
            resultText.color = Color.red; // Optional: Change the color of the result text
        }
    }
}
