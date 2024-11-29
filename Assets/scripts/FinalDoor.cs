/*using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transfer trans;
    int count = 0;
    public GameObject Door;

    
    void Start()
    {
       // trans = gameObject.AddComponent<Transfer>();
        //if (trans.ChatText.object != null)
        
            //Debug.Log("not null");
           // counter();
        
    }
     void Update()
    {
        counter();
    }
    public void counter()
    {
        //trans.ExtractChatText(text);
        //trans.RedirectPlayerMessage();
        string[] WordsToLook = { "Congratulations", "well done", "awesome", "outstanding", "excellent" };
    //string[] words = ChatText.Split('');

        foreach(string word in WordsToLook)
        {
           if(trans.ChatText.Contains(word))
            {
                count++;
                Debug.Log("count is " + count);
                break;
                
               
                
            }
            if(count>=4)
            {
                Destroy(Door,2f); 
            }
        }
    }

}*/
using UnityEngine;
using System.Collections.Generic;

public class FinalDoor : MonoBehaviour
{
    public Transfer trans;       // Reference to the Transfer script
    public GameObject Door;      // The door GameObject to be destroyed
    public int count = 0;       // Tracks the number of unique words found
    private HashSet<string> matchedWords = new HashSet<string>();  // Tracks matched words
    public Animator animator3;
    //public GameObject iris;

    void Update()
    {
        //counter();
        if (count >= 4)
        {
            Destroy(Door, 2f);   // Destroy the door after 2 seconds
            Debug.Log("Door destroyed!");
            animator3.SetBool("Open", true);
            return;             // Exit to avoid further processing
        }
    }

    public void counter()
    {
        if(count >= 4)
        {
            return;
        }
        // Words to check for in the NPC's text
        string[] WordsToLook = { "Congratulations", "well done", "awesome", "outstanding", "excellent","bravo","wonderful","fantastic","great job" };

        foreach (string word in WordsToLook)
        {
            // Check if the ChatText contains the word and hasn't been matched before
            if (trans.ChatText.Contains(word)) //&& !matchedWords.Contains(word))
            {
                matchedWords.Add(word);  // Add the word to the matched set
                count++;                 // Increment the count
                Debug.Log("Word matched: " + word + ", count is " + count);

                // Check if the required number of matches is reached
                if (count >= 4)
                {
                    animator3.SetBool("Open",true);
                    Debug.Log("Door has been destroyed!");
                    return;             // Exit to avoid further processing
                }
                else
                {
                    //iris.SetActive(false);
                    Debug.Log("you lost");
                }
            }
        }
    }
}