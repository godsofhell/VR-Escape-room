using Convai.Scripts.Runtime.Core;
using Convai.Scripts.Runtime.UI;
using UnityEngine;

public class Transfer : MonoBehaviour
{

    [SerializeField] private ConvaiNPC ConvaiNPC_B;
    //[SerializeField] private ConvaiNPC ConvaiNPC_A;

    [SerializeField] private ConvaiChatUIHandler ConvaiTranscript;
    public FinalDoor door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public static void Main()
    {
        ConvaiChatUIHandler handler = new ConvaiChatUIHandler();
    }
    public string ChatText;
    
    private void OnEnable() => ConvaiChatUIHandler.OnTextSent += ExtractChatText;
    private void OnDisable() => ConvaiChatUIHandler.OnTextSent -= ExtractChatText;

    public void ExtractChatText(string text)
    {
        
        ChatText = text;
        string[] WordsToLook = { "Congratulations", "well done", "awesome", "outstanding", "excellent", "bravo", "wonderful", "fantastic", "great job" };
        foreach (string word in WordsToLook)
        {
            // Check if the ChatText contains the word and hasn't been matched before
            if (ChatText.ToLower().Contains(word.ToLower())) //&& !matchedWords.Contains(word))
            {
                door.count++;
                Debug.Log(door.count);
            }
        }
    }
    
    public void RedirectPlayerMessage()
    {
        ConvaiNPC_B.SendTextDataAsync(ChatText);
    }
}

