using Convai.Scripts.Runtime.Core;
using Convai.Scripts.Runtime.UI;
using UnityEngine;

public class Transfer : MonoBehaviour
{

    [SerializeField] private ConvaiNPC ConvaiNPC_B;
    //[SerializeField] private ConvaiNPC ConvaiNPC_A;

    [SerializeField] private ConvaiChatUIHandler ConvaiTranscript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        Debug.Log(ChatText);
    }
    public void RedirectPlayerMessage()
    {
        ConvaiNPC_B.SendTextDataAsync(ChatText);
    }
}

