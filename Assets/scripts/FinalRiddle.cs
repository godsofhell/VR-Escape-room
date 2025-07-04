using UnityEngine;
using System.Collections.Generic;

public class FinalRiddle : MonoBehaviour
{
    [SerializeField] private GameObject door;       // Reference to the door
    [SerializeField] private int requiredMatches = 3; // Number of matches needed to destroy the door
    private int matchCount = 0;                     // Counter for keyword matches
    private HashSet<string> processedLines = new HashSet<string>(); // Tracks processed lines

    public Transfer trans;
    // Predefined keywords to match
    private readonly string[] keywords = { "congratulations", "well done", "excellent", "awesome" };
    void Update()
    {
        if (string.IsNullOrEmpty(trans.ChatText))
            return;
        else

            CheckConversation(trans.ChatText);
        
    }

    // Function to check a line of text
    public void CheckConversation(string conversation)
    {
        // Skip if the conversation has already been processed
        if (processedLines.Contains(conversation))
        {
            Debug.Log($"Line already processed: {conversation}");
            return;
        }

        // Add this line to the processed set
        processedLines.Add(conversation);

        // Check for keywords in the new line
        foreach (string keyword in keywords)
        {
            if (trans.ChatText.Contains(keyword)) // Case-insensitive match
            {
                matchCount++;
                Debug.Log($"Keyword '{keyword}' found! Match count: {matchCount}");

                // Destroy the door if the required match count is reached
                if (matchCount >= requiredMatches)
                {
                    Destroy(door);
                    Debug.Log("Door destroyed!");
                    return; // Exit after destroying the door
                }

                break; // Avoid checking other keywords in this line
            }
        }
    }
}
