using UnityEngine;

public class KeywordCounter : MonoBehaviour
{
    public int correctThreshold = 3; // Number of correct responses needed
    private int correctCount = 0; // Tracks correct answers

    public GameObject escapeDoor; // Reference to the door

    // Call this method whenever the NPC speaks
    public void CheckForKeywords(string npcDialogue)
    {
        // List of keywords to detect
        string[] positiveKeywords = { "WOW", "AWESOME", "CONGRATULATIONS", "CORRECT" };

        // Check if any keyword is present in the NPC's dialogue
        foreach (string keyword in positiveKeywords)
        {
            if (npcDialogue.ToUpper().Contains(keyword))
            {
                correctCount++;
                Debug.Log($"Keyword detected: {keyword}. Total correct count: {correctCount}");

                if (correctCount >= correctThreshold)
                {
                    UnlockDoor();
                }

                break; // Exit loop after detecting a keyword
            }
        }
    }

    private void UnlockDoor()
    {
        Debug.Log("All riddles solved! Unlocking the door.");
        if (escapeDoor != null)
        {
            Destroy(escapeDoor); // Example: Destroy the door to unlock the escape
        }
    }
}

